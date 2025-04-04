using PicPay.Simplificado.Domain.Core.Interfaces.Commands.Result;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarioComun;

namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands;

public interface IUsuarioComunCommandHandler
{
    Task<CommandResult> Handler(UsuarioComumCreateCommand command);
}