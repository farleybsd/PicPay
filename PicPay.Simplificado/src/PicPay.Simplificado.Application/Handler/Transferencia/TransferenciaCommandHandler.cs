using PicPay.Simplificado.Application.Response.Transacaoes;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;
using PicPay.Simplificado.Domain.Core.Interfaces.Log;
using PicPay.Simplificado.Domain.Core.Interfaces.Patterns;
using PicPay.Simplificado.Service.Interfaces;

namespace PicPay.Simplificado.Application.Handler.Transferencia;

public class TransferenciaCommandHandler : ITransferenciaCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IAuthorizeGateway _authorizeGateway;
    private readonly ILogService<TransferenciaCommandHandler> _log;
    private readonly List<ITransactionCommand> _transaction = new();
    private readonly GerenciadorDeTransacoesBancarias _gerenciador;

    public TransferenciaCommandHandler(
        IUnitOfWork uow,
        IAuthorizeGateway authorizeGateway,
        IEnumerable<ITransactionCommand> transactionCommands,
        ILogService<TransferenciaCommandHandler> log)
    {
        _uow = uow;
        _authorizeGateway = authorizeGateway;
        _transaction = transactionCommands.ToList();
        _gerenciador = new GerenciadorDeTransacoesBancarias(_transaction);
        _log = log;
    }

    public async Task<CommandResult> Handler(TransferenciaCreateCommand command)
    {
        _log.Info($"Iniciando transferência de {command.Valor} do usuário {command.IdTitular} para lojista {command.IdFavorecido}");

        var usuarioComumpagador = await _uow.UsuarioComunRepositorio.FirstAsync(x => x.Id == command.IdTitular);
        var usuarioLojistaFavorecido = await _uow.UsuarioLojistaRepositorio.FirstAsync(x => x.Id == command.IdFavorecido);

        if (usuarioComumpagador is null)
        {
            _log.Warn($"Usuário pagador {command.IdTitular} não encontrado.");
            return new CommandResult(false, $"Dados inválidos para {command.IdTitular}");
        }

        if (usuarioLojistaFavorecido is null)
        {
            _log.Warn($"Lojista favorecido {command.IdFavorecido} não encontrado.");
            return new CommandResult(false, $"Dados inválidos para {command.IdFavorecido}");
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
                    .setTransacaoDestino(new TransacaoDestino(usuarioLojistaFavorecido.UsuarioNome.NomeCompleto))
                    .setTransferenciaSaldo(new TransferenciaSaldo((double)command.Valor))
                    .setUsuarioOrigemId(usuarioComumpagador.Id)
                    .setTransferenciaDestinoId(usuarioLojistaFavorecido.Id)
                    .setSucessoNaTransferencia(response.Dados.Autorizacao)
                    .Builde();

                var debitar = new DebitarTransaction(usuarioComumpagador.UsuarioSaldo, (double)command.Valor);
                var creditar = new CreditarTransaction(usuarioLojistaFavorecido.UsuarioSaldo, (double)command.Valor);
                _gerenciador.ExecutarTransacao(debitar);
                _gerenciador.ExecutarTransacao(creditar);

                await _uow.BeginTransactionAsync();
                await _uow.TransfereneciaRepositorio.AddAsync(transacao);
                _uow.UsuarioComunRepositorio.Update(usuarioComumpagador);
                _uow.UsuarioLojistaRepositorio.Update(usuarioLojistaFavorecido);

                if (_uow.Commit())
                {
                    await _uow.CommitTransactionAsync();
                    _log.Info("Transação concluída com sucesso.");

                    var usuarioComumpagadorResponse = await _uow.UsuarioComunRepositorio.FirstAsync(x => x.Id == command.IdTitular);
                    var usuarioLojistaFavorecidoResponse = await _uow.UsuarioLojistaRepositorio.FirstAsync(x => x.Id == command.IdFavorecido);

                    var responseTransacao = new TransacaoCreateResponse
                    {
                        NomeTitular = usuarioComumpagadorResponse.UsuarioNome.NomeCompleto,
                        SaldoTitular = usuarioComumpagadorResponse.UsuarioSaldo.Saldo,
                        NomeFavorecido = usuarioLojistaFavorecidoResponse.UsuarioNome.NomeCompleto,
                        SaldoFavorecido = usuarioLojistaFavorecidoResponse.UsuarioSaldo.Saldo
                    };

                    return new CommandResult(true, "Transacao criada com sucesso", responseTransacao);
                }

                await _uow.RollbackTransactionAsync();
                _gerenciador.DesfazerTransacao(debitar);
                _gerenciador.DesfazerTransacao(creditar);
                _log.Error("Falha ao salvar transação no banco.");
                return new CommandResult(false, "Erro ao salvar transação");
            }

            _log.Warn("Transação não autorizada pelo serviço externo.");
            return new CommandResult(false, "Transação não autorizada");
        }
        catch (Exception ex)
        {
            _log.Error("Erro inesperado ao processar transferência.", ex);
            await _uow.RollbackTransactionAsync();
            return new CommandResult(false, "Erro interno ao processar a transferência.");
        }
    }
}
