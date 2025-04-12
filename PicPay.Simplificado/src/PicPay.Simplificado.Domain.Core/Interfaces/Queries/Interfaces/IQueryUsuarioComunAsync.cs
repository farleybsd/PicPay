

namespace PicPay.Simplificado.Domain.Core.Interfaces.Queries.Interfaces;

public interface IQueryUsuarioComunAsync
{
    Task<QueryResult<UsuarioComumSearchByCpfResponse>> SearchCommonUserByCpf(string cpf);
}