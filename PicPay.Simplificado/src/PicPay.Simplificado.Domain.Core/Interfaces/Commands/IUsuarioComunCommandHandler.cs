namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands;

public interface IUsuarioComunCommandHandler
{
    Task<CommandResult> Handler(UsuarioComumCreateCommand command);
}