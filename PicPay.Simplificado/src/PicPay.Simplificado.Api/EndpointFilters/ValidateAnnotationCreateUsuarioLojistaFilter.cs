﻿namespace PicPay.Simplificado.Api.EndpointFilters;

public class ValidateAnnotationCreateUsuarioLojistaFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var dto = context.GetArgument<UsuarioLojistaCreateRequest>(0); //UsuarioLojistaCreateRequest

        if (!SimpleValidator.TryValidate(dto, out var validationErrors))
        {
            return TypedResults.ValidationProblem(validationErrors);
        }

        return await next(context);
    }
}