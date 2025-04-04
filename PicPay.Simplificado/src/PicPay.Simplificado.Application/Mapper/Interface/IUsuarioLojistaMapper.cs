using PicPay.Simplificado.Application.Request.UsuarioComum.Create;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarioLojista;

namespace PicPay.Simplificado.Application.Mapper.Interface
{
    public interface IUsuarioLojistaMapper
    {
        UsuarioLojistaCreateCommand ConvertToCommandCreate(UsuarioLojistaCreateRequest request);
    }
}