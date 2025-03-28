namespace PicPay.Simplificado.Domain.Entidades;

public class Transferencia : TransferenciaBase
{
    public int UsuarioOrigemId { get; set; }
    public TransacaoOrigem TransferenciaOrigem { get; private set; }
    public TransacaoDestino TransferenciaDestino { get; private set; }
    public int UsuarioDestinoId { get; set; }
    public FormasPagamento TipoPagamento { get; init; } = FormasPagamento.Dinheiro;
    public TransferenciaSaldo TransferenciaSaldo { get; private set; }

    public Transferencia()
    { }

    public class Builder
    {
        private readonly Transferencia _transferencia;

        public Builder()
        {
            _transferencia = new Transferencia();
        }

        public Builder setTransacaoOrigem(TransacaoOrigem transacaoOrigem)
        {
            _transferencia.TransferenciaOrigem = transacaoOrigem;
            return this;
        }

        public Builder setTransacaoDestino(TransacaoDestino transacaoDestino)
        {
            _transferencia.TransferenciaDestino = transacaoDestino;
            return this;
        }

        public Builder setTransferenciaSaldo(TransferenciaSaldo transferenciaSaldo)
        {
            _transferencia.TransferenciaSaldo = transferenciaSaldo;
            return this;
        }

        public Transferencia Builde()
        {
            return _transferencia;
        }
    }
}