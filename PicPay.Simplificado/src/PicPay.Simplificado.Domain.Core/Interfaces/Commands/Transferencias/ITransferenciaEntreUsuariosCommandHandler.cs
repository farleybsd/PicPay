namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;

public interface ITransferenciaEntreUsuariosCommandHandler
{
    Task<CommandResult> Handler(TransferenciaEntreUsuariosCreateCommand command);
}