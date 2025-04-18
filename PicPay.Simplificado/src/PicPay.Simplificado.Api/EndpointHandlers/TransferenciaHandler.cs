﻿namespace PicPay.Simplificado.Api.EndpointHandlers;

public static class TransferenciaHandler
{
    public static async Task<IResult> TransferirAsync(
    [FromBody] TransferenciaCreateRequest request,
    [FromServices] ITransferenciaCommandHandler commandHandler,
    [FromServices] ITransferenciaMapper usuarioComumMapper)
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

        var response = (TransacaoCreateResponse)result.Data;

        return TypedResults.Ok(response);
    }

    public static async Task<IResult> TransferirUsuarioParaUsuarioAsync(
    [FromBody] TransferenciaEntreUsuariosCreateRequest request,
    [FromServices] ITransferenciaEntreUsuariosCommandHandler commandHandler,
    [FromServices] ITransferenciaMapper usuarioComumMapper)
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

        var response = (TransacaoCreateResponse)result.Data;

        return TypedResults.Ok(response);
    }
}