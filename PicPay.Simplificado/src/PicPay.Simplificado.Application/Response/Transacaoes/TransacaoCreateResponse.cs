namespace PicPay.Simplificado.Application.Response.Transacaoes;

public class TransacaoCreateResponse
{
    public string NomeTitular { get; set; }
    public double SaldoTitular { get; set; }
    public string NomeFavorecido { get; set; }
    public double SaldoFavorecido { get; set; }
}