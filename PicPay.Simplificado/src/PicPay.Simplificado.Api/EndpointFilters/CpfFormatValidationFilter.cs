namespace PicPay.Simplificado.Api.EndpointFilters
{
    public class CpfFormatValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            string cpfParam = context.GetArgument<string>(0);

            string cpfSomenteNumeros = new string(cpfParam.Where(char.IsDigit).ToArray());

            if (cpfSomenteNumeros.Length != 11)
            {
                return Results.BadRequest("CPF inválido. Deve conter 11 dígitos numéricos.");
            }

            var result = await next.Invoke(context);
            return result;
        }
    }
}