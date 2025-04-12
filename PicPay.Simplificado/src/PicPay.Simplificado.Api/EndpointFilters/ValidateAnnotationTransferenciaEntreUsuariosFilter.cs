namespace PicPay.Simplificado.Api.EndpointFilters;

public class ValidateAnnotationTransferenciaEntreUsuariosFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var dto = context.GetArgument<TransferenciaEntreUsuariosCreateRequest>(0); //UsuarioComumCreateRequest

        if (!SimpleValidator.TryValidate(dto, out var validationErrors))
        {
            return TypedResults.ValidationProblem(validationErrors);
        }

        return await next(context);
    }
}