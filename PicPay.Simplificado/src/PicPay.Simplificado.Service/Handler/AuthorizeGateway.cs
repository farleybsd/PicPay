namespace PicPay.Simplificado.Service.Handler;
public class AuthorizeGateway(HttpClient httpClient) : IAuthorizeGateway
{
    public async Task<AuthorizeResponse> AutorizarTransracao()
    {
        if (httpClient.BaseAddress == null)
        {
            throw new InvalidOperationException("O HttpClient foi injetado sem um BaseAddress configurado.");
        }

        var httpResponse = await httpClient.GetAsync("");

        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Erro ao Comunicar com o Autorizador. Código: {httpResponse.StatusCode}");
        }

        var response = await httpResponse.Content.ReadFromJsonAsync<AuthorizeResponse>();

        return response ?? throw new InvalidOperationException($"Resposta nula do Autorizador ");
    }
}
