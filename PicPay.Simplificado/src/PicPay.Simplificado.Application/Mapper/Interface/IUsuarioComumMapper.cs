using PicPay.Simplificado.Application.Request.UsuarioComum.Create;

namespace PicPay.Simplificado.Application.Mapper.Interface
{
    public interface IUsuarioComumMapper
    {
        UsuarioComumCreateCommand ConvertToCommandCreate(UsuarioComumCreateRequest request);
    }
}
