namespace PicPay.Simplificado.Application.Mapper.Interface
{
    public interface IUsuarioLojistaMapper
    {
        UsuarioLojistaCreateCommand ConvertToCommandCreate(UsuarioLojistaCreateRequest request);
    }
}