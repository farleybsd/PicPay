
namespace PicPay.Simplificado.Service.Response
{
    public class AuthorizeResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public Dados Dados { get; set; }
    }

    public class Dados
    {
        [JsonPropertyName("authorization")]
        public bool Autorizacao { get; set; }
    }
}