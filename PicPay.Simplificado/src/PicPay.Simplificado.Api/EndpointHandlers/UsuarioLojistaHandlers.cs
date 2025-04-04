using Microsoft.AspNetCore.Mvc;
using PicPay.Simplificado.Application.Mapper.Interface;
using PicPay.Simplificado.Application.Request.UsuarioComum.Create;
using PicPay.Simplificado.Application.Response.UsuarioComum.Create;
using PicPay.Simplificado.Application.Response.UsuariosLojistas;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarrioLojistas;
using PicPay.Simplificado.Domain.Core.Interfaces.Queries.Interfaces;

namespace PicPay.Simplificado.Api.EndpointHandlers;
public static class UsuarioLojistaHandlers
{
    public static async Task<IResult> CreateUsuarioLojistaAsync(
    [FromBody] UsuarioLojistaCreateRequest request,
    [FromServices] IUsuarioLojistaCommandHandler commandHandler,
    [FromServices] IUsuarioLojistaMapper usuarioComumMapper)
    {
        if (request == null)
        {
            return TypedResults.BadRequest("Dados do cliente não podem ser nulos.");
        }

        var createCommand = usuarioComumMapper.ConvertToCommandCreate(request);
        var result = await commandHandler.Handler(createCommand);

        if (!result.Success)
        {
            return TypedResults.BadRequest(result.Message);
        }

        var response = (UsuarioLojistaCreateResponse)result.Data;

        return TypedResults.CreatedAtRoute(
        routeName: "GetUsuarioLojista",
        routeValues: new { Cnpj = response.Cnpj },
        value: response);
    }


    public static async Task<IResult> GetUsuarioLojistaAsync(string cnpj,
     [FromServices] IQueryUsuarioLojistaAsync queryUsuarioLojistaAsync)
    {
        var result = await queryUsuarioLojistaAsync.SearchLojistaUserByCnpj(cnpj);

        if (!result.Success)
            return TypedResults.BadRequest(result.Message);

        if (result.Data == null)
            return TypedResults.NotFound("Usuário Lojista não encontrado.");

        return TypedResults.Ok(result.Data);
    }

}
