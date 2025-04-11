using PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;

namespace PicPay.Simplificado.Application.Mapper
{
    public class TransferenciaMapper : ITransferenciaMapper
    {
     public TransferenciaCreateCommand ConvertToCommandCreate(TransferenciaCreateRequest request) => new TransferenciaCreateCommand(request.Valor,request.IdTitular,request.IdFavorecido);
        
    }
}