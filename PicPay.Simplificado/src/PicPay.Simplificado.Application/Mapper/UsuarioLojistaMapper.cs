

namespace PicPay.Simplificado.Application.Mapper
{
    public class UsuarioLojistaMapper : IUsuarioLojistaMapper
    {
        public UsuarioLojistaCreateCommand ConvertToCommandCreate(UsuarioLojistaCreateRequest request) => new UsuarioLojistaCreateCommand(request.NomeCompleto, request.CNPJ, request.Email, request.Senha);
    }
}