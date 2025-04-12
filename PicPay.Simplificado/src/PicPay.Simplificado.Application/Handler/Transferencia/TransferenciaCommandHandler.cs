
using PicPay.Simplificado.Application.Response.Transacaoes;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;
using PicPay.Simplificado.Domain.Core.Interfaces.Patterns;
using PicPay.Simplificado.Service.Interfaces;

namespace PicPay.Simplificado.Application.Handler.Transferencia;
public class TransferenciaCommandHandler : ITransferenciaCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IAuthorizeGateway _authorizeGateway;
    private new List<ITransactionCommand> _transaction = new List<ITransactionCommand>();
    private GerenciadorDeTransacoesBancarias _gerenciador;
    public TransferenciaCommandHandler(
    IUnitOfWork uow,
    IAuthorizeGateway authorizeGateway,
    IEnumerable<ITransactionCommand> transactionCommands)
    {
        _uow = uow;
        _authorizeGateway = authorizeGateway;
        _transaction = transactionCommands.ToList();
        _gerenciador = new GerenciadorDeTransacoesBancarias(_transaction);
    }


    public async Task<CommandResult> Handler(TransferenciaCreateCommand command)
    {
        var usuarioComumpagador = await _uow.UsuarioComunRepositorio.FirstAsync(x => x.Id == command.IdTitular);

        var usuarioLojistaFavorecido = await _uow.UsuarioLojistaRepositorio.FirstAsync(x => x.Id == command.IdFavorecido);

        if (usuarioComumpagador is null)
            return new CommandResult(false, $"Dados inválidos para {command.IdTitular}");

        if (usuarioLojistaFavorecido is null)
            return new CommandResult(false, $"Dados inválidos para {command.IdFavorecido}");


        if (usuarioComumpagador.TemSaldo)
        {

            // Autorizador
            var response = await _authorizeGateway.AutorizarTransracao();

            if (response.Status.Equals("success") && response.Dados.Autorizacao)
            {
                // Realizar Transacao

                var transacao = new PicPay.Simplificado.Domain.Entidades.Transferencia.Builder()
                    .setTransacaoOrigem(new TransacaoOrigem(usuarioComumpagador.UsuarioNome.NomeCompleto), usuarioComumpagador.UsuarioCategoria)
                    .setTransacaoDestino(new TransacaoDestino(usuarioLojistaFavorecido.UsuarioNome.NomeCompleto))
                    .setTransferenciaSaldo(new TransferenciaSaldo((double)command.Valor))
                    .setUsuarioOrigemId(usuarioComumpagador.Id)
                    .setTransferenciaDestinoId(usuarioLojistaFavorecido.Id)
                    .setSucessoNaTransferencia(response.Dados.Autorizacao)
                    .Builde();

                ITransactionCommand Debitar = new DebitarTransaction(usuarioComumpagador.UsuarioSaldo, (double)command.Valor);
                ITransactionCommand Creditar = new CreditarTransaction(usuarioLojistaFavorecido.UsuarioSaldo, (double)command.Valor);
                _gerenciador.ExecutarTransacao(Debitar);
                _gerenciador.ExecutarTransacao(Creditar);

                await _uow.BeginTransactionAsync();
                await _uow.TransfereneciaRepositorio.AddAsync(transacao);
                _uow.UsuarioComunRepositorio.Update(usuarioComumpagador);
                _uow.UsuarioLojistaRepositorio.Update(usuarioLojistaFavorecido);

                if (_uow.Commit())
                {
                    await _uow.CommitTransactionAsync();

                    var usuarioComumpagadorResponse = await _uow.UsuarioComunRepositorio.FirstAsync(x => x.Id == command.IdTitular);
                    var usuarioLojistaFavorecidoResponse = await _uow.UsuarioLojistaRepositorio.FirstAsync(x => x.Id == command.IdFavorecido);

                    var responseTransacao = new TransacaoCreateResponse
                    {
                        NomeTitular = usuarioComumpagadorResponse.UsuarioNome.NomeCompleto,
                        SaldoTitular = usuarioComumpagadorResponse.UsuarioSaldo.Saldo,
                        NomeFavorecido = usuarioLojistaFavorecidoResponse.UsuarioNome.NomeCompleto,
                        SaldoFavorecido = usuarioLojistaFavorecidoResponse.UsuarioSaldo.Saldo
                    };

                    return new CommandResult(true, "Transacao criado com sucesso", responseTransacao);
                }

                await _uow.RollbackTransactionAsync();
                _gerenciador.DesfazerTransacao(Debitar);
                _gerenciador.DesfazerTransacao(Creditar);
                return new CommandResult(false, "Dados inválidos");

            }
        }
        return new CommandResult(false, "Usuario Sem Saldo");


    }
}
