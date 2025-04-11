namespace PicPay.Simplificado.Application.Request.UsuarioComum.Create;
public class TransferenciaCreateRequest
{
    public decimal Valor { get; set; }
    public int IdTitular { get; set; }
    public int IdFavorecido { get; set; }

}
