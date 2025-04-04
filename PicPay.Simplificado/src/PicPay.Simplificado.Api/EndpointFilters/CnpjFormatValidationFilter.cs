using System.Text.RegularExpressions;

namespace PicPay.Simplificado.Api.EndpointFilters;
public class CnpjFormatValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        string cnpjParam = context.GetArgument<string>(0);
        string cnpjSomenteNumeros = new string(cnpjParam.Where(char.IsDigit).ToArray());

        if (!EhCnpjValido(cnpjSomenteNumeros))
        {
            return Results.BadRequest("CNPJ inválido. Deve conter 14 dígitos numéricos válidos.");
        }

        var result = await next.Invoke(context);
        return result;
    }

    private bool EhCnpjValido(string cnpj)
    {
        if (cnpj.Length != 14 || Regex.IsMatch(cnpj, @"^(\d)\1{13}$"))
            return false;

        int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj[..12];
        int soma = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        tempCnpj += digito1;
        soma = 0;

        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return cnpj.EndsWith($"{digito1}{digito2}");
    }
}
