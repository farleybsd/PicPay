namespace PicPay.Simplificado.Application.Handler.Transferencia;

public class TransferenciaEntreUsuariosCommandHandler : ITransferenciaEntreUsuariosCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IAuthorizeGateway _authorizeGateway;
    private readonly ILogService<TransferenciaEntreUsuariosCommandHandler> _log;
    private readonly List<ITransactionCommand> _transaction = new();
    private readonly GerenciadorDeTransacoesBancarias _gerenciador;

    public TransferenciaEntreUsuariosCommandHandler(
        IUnitOfWork uow,
        IAuthorizeGateway authorizeGateway,
        IEnumerable<ITransactionCommand> transactionCommands,
        ILogService<TransferenciaEntreUsuariosCommandHandler> log)
    {
        _uow = uow;
        _authorizeGateway = authorizeGateway;
        _transaction = transactionCommands.ToList();
        _gerenciador = new GerenciadorDeTransacoesBancarias(_transaction);
        _log = log;
    }

    public async Task<CommandResult> Handler(TransferenciaEntreUsuariosCreateCommand command)
    {
        _log.Info($"Iniciando transferência do usuário {command.IdTitular} para o usuário {command.IdFavorecido} no valor de {command.Valor}");

        var usuarioComumpagador = await _uow.UsuarioComunRepositorio.FirstAsync(x => x.Id == command.IdTitular);
        var usuarioComumFavorecido = await _uow.UsuarioComunRepositorio.FirstAsync(x => x.Id == command.IdFavorecido);

        if (usuarioComumpagador is null)
        {
            _log.Warn($"Usuário pagador {command.IdTitular} não encontrado.");
            return new CommandResult(false, $"Dados inválidos para {command.IdTitular}");
        }

        if (!usuarioComumpagador.TemSaldo)
        {
            _log.Warn($"Usuário pagador {command.IdTitular} não possui saldo suficiente.");
            return new CommandResult(false, "Usuario Sem Saldo");
        }

        try
        {
            var response = await _authorizeGateway.AutorizarTransracao();
            _log.Info($"Resposta do autorizador: Status = {response.Status}, Autorização = {response.Dados.Autorizacao}");

            if (response.Status.Equals("success") && response.Dados.Autorizacao)
            {
                var transacao = new PicPay.Simplificado.Domain.Entidades.Transferencia.Builder()
                    .setTransacaoOrigem(new TransacaoOrigem(usuarioComumpagador.UsuarioNome.NomeCompleto), usuarioComumpagador.UsuarioCategoria)
                    .setTransacaoDestino(new TransacaoDestino(usuarioComumFavorecido.UsuarioNome.NomeCompleto))
                    .setTransferenciaSaldo(new TransferenciaSaldo((double)command.Valor))
                    .setUsuarioOrigemId(usuarioComumpagador.Id)
                    .setTransferenciaDestinoId(usuarioComumFavorecido.Id)
                    .setSucessoNaTransferencia(response.Dados.Autorizacao)
                    .Builde();

                var debitar = new DebitarTransaction(usuarioComumpagador.UsuarioSaldo, (double)command.Valor);
                var creditar = new CreditarTransaction(usuarioComumFavorecido.UsuarioSaldo, (double)command.Valor);
                _gerenciador.ExecutarTransacao(debitar);
                _gerenciador.ExecutarTransacao(creditar);

                await _uow.BeginTransactionAsync();
                await _uow.TransfereneciaRepositorio.AddAsync(transacao);
                _uow.UsuarioComunRepositorio.Update(usuarioComumpagador);
                _uow.UsuarioComunRepositorio.Update(usuarioComumFavorecido);

                if (_uow.Commit())
                {
                    await _uow.CommitTransactionAsync();
                    _log.Info("Transação realizada com sucesso.");

                    var usuarioComumpagadorResponse = await _uow.UsuarioComunRepositorio.FirstAsync(x => x.Id == command.IdTitular);
                    var usuarioComumFavorecidoResponse = await _uow.UsuarioComunRepositorio.FirstAsync(x => x.Id == command.IdFavorecido);

                    var responseTransacao = new TransacaoCreateResponse
                    {
                        NomeTitular = usuarioComumpagadorResponse.UsuarioNome.NomeCompleto,
                        SaldoTitular = usuarioComumpagadorResponse.UsuarioSaldo.Saldo,
                        NomeFavorecido = usuarioComumFavorecidoResponse.UsuarioNome.NomeCompleto,
                        SaldoFavorecido = usuarioComumFavorecidoResponse.UsuarioSaldo.Saldo
                    };

                    return new CommandResult(true, "Transacao criada com sucesso", responseTransacao);
                }

                await _uow.RollbackTransactionAsync();
                _gerenciador.DesfazerTransacao(debitar);
                _gerenciador.DesfazerTransacao(creditar);
                _log.Error("Falha ao salvar transação no banco.");
                return new CommandResult(false, "Erro ao salvar transação");
            }
            else
            {
                _log.Warn("Transação não autorizada pelo serviço externo.");
                return new CommandResult(false, "Transação não autorizada");
            }
        }
        catch (Exception ex)
        {
            _log.Error("Erro inesperado ao processar transferência", ex);
            await _uow.RollbackTransactionAsync();
            return new CommandResult(false, "Erro interno ao processar a transferência.");
        }
    }
}