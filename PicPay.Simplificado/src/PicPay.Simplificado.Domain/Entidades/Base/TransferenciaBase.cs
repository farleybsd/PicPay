namespace PicPay.Simplificado.Domain.Entidades.Base;

public class TransferenciaBase
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public bool SucessoNaTransferencia { get; set; }
}