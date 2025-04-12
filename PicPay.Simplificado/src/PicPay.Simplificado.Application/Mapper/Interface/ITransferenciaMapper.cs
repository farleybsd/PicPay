namespace PicPay.Simplificado.Application.Mapper.Interface
{
    public interface ITransferenciaMapper
    {
        TransferenciaCreateCommand ConvertToCommandCreate(TransferenciaCreateRequest request);

        TransferenciaEntreUsuariosCreateCommand ConvertToCommandCreate(TransferenciaEntreUsuariosCreateRequest request);
    }
}