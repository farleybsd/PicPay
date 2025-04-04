using PicPay.Simplificado.Application.Mapper.Interface;
using PicPay.Simplificado.Application.Request.UsuarioComum.Create;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarioLojista;

namespace PicPay.Simplificado.Application.Mapper
{
    public class UsuarioLojistaMapper : IUsuarioLojistaMapper
    {
        public UsuarioLojistaCreateCommand ConvertToCommandCreate(UsuarioLojistaCreateRequest request) => new UsuarioLojistaCreateCommand(request.NomeCompleto, request.CNPJ, request.Email, request.Senha);
    }
}