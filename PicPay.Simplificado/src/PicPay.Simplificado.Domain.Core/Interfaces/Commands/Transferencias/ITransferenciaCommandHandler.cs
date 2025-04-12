namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;

public interface ITransferenciaCommandHandler
{
    Task<CommandResult> Handler(TransferenciaCreateCommand command);
}