using PicPay.Simplificado.Application.Mapper.Interface;
using PicPay.Simplificado.Application.Request.UsuarioComum.Create;

namespace PicPay.Simplificado.Application.Mapper
{
    public class UsuarioComumMapper : IUsuarioComumMapper
    {
        public UsuarioComumCreateCommand ConvertToCommandCreate(UsuarioComumCreateRequest request) => new UsuarioComumCreateCommand(request.NomeCompleto, request.Cpf, request.Email, request.Senha);
    }
}