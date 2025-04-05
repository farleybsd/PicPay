namespace PicPay.Simplificado.Service.Response;

public class AuthorizeResponse
{
    public string Status { get; set; }
    public Dados Dados { get; set; }
}
public class Dados
{
    public bool Autorizacao { get; set; }
}