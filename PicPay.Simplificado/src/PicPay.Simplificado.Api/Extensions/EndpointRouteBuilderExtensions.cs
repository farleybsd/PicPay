using PicPay.Simplificado.Api.EndpointHandlers;

namespace PicPay.Simplificado.Api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterUsuarioComumEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var usuarioComum = endpointRouteBuilder.MapGroup("/UsuarioComum");

        usuarioComum.MapPost("", UsuarioComumHandlers.CreateUsuarioComumAsync)
                    .WithSummary("Criar um novo Usuário Comum")
                    .WithDescription("Cadastra um novo usuário comum no sistema, validando unicidade de CPF e e-mail. Usuários comuns podem realizar e receber transferências. Retorna o usuário criado ou mensagem de erro em caso de dados inválidos.");

    }
}
