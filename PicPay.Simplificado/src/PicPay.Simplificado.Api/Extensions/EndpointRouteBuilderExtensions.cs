using PicPay.Simplificado.Api.EndpointFilters;
using PicPay.Simplificado.Api.EndpointHandlers;

namespace PicPay.Simplificado.Api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterUsuarioComumEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var usuarioComum = endpointRouteBuilder.MapGroup("/UsuarioComum");
        var usuarioLojista = endpointRouteBuilder.MapGroup("/UsuarioLojista");

        usuarioComum.MapPost("", UsuarioComumHandlers.CreateUsuarioComumAsync)
                     .WithSummary("Criar um novo Usuário Comum")
                     .WithDescription("Cadastra um novo usuário comum no sistema, validando unicidade de CPF e e-mail.")
                     .AddEndpointFilter<ValidateAnnotationCreateUsuarioComumFilter>(); ;


        endpointRouteBuilder.MapGet("/{cpf}", UsuarioComumHandlers.GetUsuarioComumAsync)
                            .WithName("GetUsuarioComum")
                            .WithSummary("Buscar usuário comum")
                            .WithDescription("Busca um usuário comum cadastrado no sistema filtrando pelo CPF.")
                            .AddEndpointFilter<CpfFormatValidationFilter>();


        usuarioLojista.MapPost("", UsuarioLojistaHandlers.CreateUsuarioLojistaAsync)
                    .WithSummary("Criar um novo Usuário Lojista")
                    .WithDescription("Cadastra um novo usuário Lojista no sistema, validando unicidade de CNPJ e e-mail.")
                    .AddEndpointFilter<ValidateAnnotationCreateUsuarioComumFilter>(); ;


        usuarioLojista.MapGet("/{Cnpj}", UsuarioLojistaHandlers.GetUsuarioLojistaAsync)
                            .WithName("GetUsuarioLojista")
                            .WithSummary("Buscar usuário comum")
                            .WithDescription("Busca um usuário comum cadastrado no sistema filtrando pelo CNPJ.")
                            .AddEndpointFilter<CnpjFormatValidationFilter>();



    }
}
