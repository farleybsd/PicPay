namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarrioLojistas;

public interface IUsuarioLojistaCommandHandler
{
    Task<CommandResult> Handler(UsuarioLojistaCreateCommand command);
}