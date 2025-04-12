namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;
public class TransferenciaEntreUsuariosCreateCommand
{
    public decimal Valor { get; set; }
    public int IdTitular { get; set; }
    public int IdFavorecido { get; set; }
    public TransferenciaEntreUsuariosCreateCommand(decimal valor, int idTitular, int idFavorecido)
    {
        Valor = valor;
        IdTitular = idTitular;
        IdFavorecido = idFavorecido;
    }
       
}
