using PicPay.Simplificado.Domain.Core.Interfaces.Queries.Interfaces;
using PicPay.Simplificado.Domain.Core.Interfaces.Queries.Result;

namespace PicPay.Simplificado.Application.Handler.Queries.UsuarioComum;

public class QueryUsuarioLojistaAsync : IQueryUsuarioLojistaAsync
{
    private readonly IUnitOfWork _uow;

    public QueryUsuarioLojistaAsync(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<QueryResult<UsuarioLojistaSearchByCnpjResponse>> SearchLojistaUserByCnpj(string cnpj)
    {
        try
        {
            var usuarioComumResponse = await _uow.UsuarioLojistaRepositorio.FirstAsync(x => x.UsuarioCnpj.Cnpj == cnpj);

            if (usuarioComumResponse == null)
                return new QueryResult<UsuarioLojistaSearchByCnpjResponse>(false, "Usuário não encontrado.");

            var response = new UsuarioLojistaSearchByCnpjResponse
            {
                NomeCompleto = usuarioComumResponse.UsuarioNome.ToString(),
                Cnpj = usuarioComumResponse.UsuarioCnpj.ToString(),
                Email = usuarioComumResponse.UsuarioEmail.ToString()
            };

            return new QueryResult<UsuarioLojistaSearchByCnpjResponse>(true, "Usuário recuperado com sucesso")
            {
                Data = response
            };
        }
        catch (Exception ex)
        {
            return new QueryResult<UsuarioLojistaSearchByCnpjResponse>(false, $"Erro ao recuperar usuário: {ex.Message}");
        }
    }
}