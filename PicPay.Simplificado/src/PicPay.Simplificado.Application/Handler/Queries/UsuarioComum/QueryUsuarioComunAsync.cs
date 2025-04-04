using PicPay.Simplificado.Domain.Core.Interfaces.Queries.Interfaces;
using PicPay.Simplificado.Domain.Core.Interfaces.Queries.Result;

namespace PicPay.Simplificado.Application.Handler.Queries.UsuarioComum;

public class QueryUsuarioComunAsync : IQueryUsuarioComunAsync
{
    private readonly IUnitOfWork _uow;

    public QueryUsuarioComunAsync(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<QueryResult<UsuarioComumSearchByCpfResponse>> SearchCommonUserByCpf(string cpf)
    {
        try
        {
            var usuarioComumResponse = await _uow.UsuarioComunRepositorio.FirstAsync(x => x.UsuarioCpf.Cpf == cpf);

            if (usuarioComumResponse == null)
                return new QueryResult<UsuarioComumSearchByCpfResponse>(false, "Usuário não encontrado.");

            var response = new UsuarioComumSearchByCpfResponse
            {
                NomeCompleto = usuarioComumResponse.UsuarioNome.ToString(),
                Cpf = usuarioComumResponse.UsuarioCpf.ToString(),
                Email = usuarioComumResponse.UsuarioEmail.ToString()
            };

            return new QueryResult<UsuarioComumSearchByCpfResponse>(true, "Usuário recuperado com sucesso")
            {
                Data = response
            };
        }
        catch (Exception ex)
        {
            return new QueryResult<UsuarioComumSearchByCpfResponse>(false, $"Erro ao recuperar usuário: {ex.Message}");
        }
    }
}