using PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;

namespace PicPay.Simplificado.Application.Mapper
{
    public class TransferenciaMapper : ITransferenciaMapper
    {
        public TransferenciaCreateCommand ConvertToCommandCreate(TransferenciaCreateRequest request) => new TransferenciaCreateCommand(request.Valor, request.IdTitular, request.IdFavorecido);

        public TransferenciaEntreUsuariosCreateCommand ConvertToCommandCreate(TransferenciaEntreUsuariosCreateRequest request) => new TransferenciaEntreUsuariosCreateCommand(request.Valor, request.IdTitular, request.IdFavorecido);
    }
}