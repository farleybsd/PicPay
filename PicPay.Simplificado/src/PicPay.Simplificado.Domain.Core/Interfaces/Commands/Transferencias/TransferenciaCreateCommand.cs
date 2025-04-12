namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;

public class TransferenciaCreateCommand
{
    public decimal Valor { get; set; }
    public int IdTitular { get; set; }
    public int IdFavorecido { get; set; }

    public TransferenciaCreateCommand(decimal valor, int idTitular, int idFavorecido)
    {
        Valor = valor;
        IdTitular = idTitular;
        IdFavorecido = idFavorecido;
    }
}