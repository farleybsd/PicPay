namespace PicPay.Simplificado.Domain.Entidades.Base;

public class UsuarioBase
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public StatusUsuario StatusUsuario { get; set; }
}