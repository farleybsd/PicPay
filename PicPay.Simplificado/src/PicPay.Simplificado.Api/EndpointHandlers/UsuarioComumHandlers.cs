using Microsoft.AspNetCore.Mvc;
using PicPay.Simplificado.Application.Mapper.Interface;
using PicPay.Simplificado.Application.Request.UsuarioComum.Create;
using PicPay.Simplificado.Application.Response.UsuarioComum.Create;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands;

namespace PicPay.Simplificado.Api.EndpointHandlers;
public static class UsuarioComumHandlers
{
    public static async Task<IResult> CreateUsuarioComumAsync(
    [FromBody] UsuarioComumCreateRequest request,
    [FromServices] IUsuarioComunCommandHandler commandHandler,
    [FromServices] IUsuarioComumMapper usuarioComumMapper)
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

        var response = (UsuarioComumCreateResponse)result.Data;

        return TypedResults.CreatedAtRoute(
        routeName: "GetUsuarioComum",
        routeValues: new { cpf = response.Cpf },
        value: response);

    }
}
