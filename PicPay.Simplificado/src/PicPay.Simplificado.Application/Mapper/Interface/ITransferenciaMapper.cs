using PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;

namespace PicPay.Simplificado.Application.Mapper.Interface
{
    public interface ITransferenciaMapper
    {
        TransferenciaCreateCommand ConvertToCommandCreate(TransferenciaCreateRequest request);
    }
}