namespace PicPay.Simplificado.Infrastructure.Data.Mappings;
public class TransferenciaMapping : IEntityTypeConfiguration<Transferencia>
{
    public void Configure(EntityTypeBuilder<Transferencia> builder)
    {
        builder.HasKey(t => t.Id);

        // Mapping do TransferenciaOrigem
        builder.OwnsOne(t => t.TransferenciaOrigem, origem =>
        {
            origem.Property(o => o.NomeCompleto)
                  .HasColumnName("NomeOrigem")
                  .HasMaxLength(60)
                  .IsRequired();
        });

        // Mapping do TransferenciaDestino
        builder.OwnsOne(t => t.TransferenciaDestino, destino =>
        {
            destino.Property(d => d.NomeCompleto)
                   .HasColumnName("NomeDestino")
                   .HasMaxLength(60)
                   .IsRequired();
        });

        // Mapping do TransferenciaSaldo
        builder.OwnsOne(t => t.TransferenciaSaldo, saldo =>
        {
            saldo.Property(s => s.Saldo)
                 .HasColumnName("SaldoTransferencia")
                 .IsRequired();
        });

        // Campo Enum
        builder.Property(t => t.TipoPagamento)
               .HasConversion<string>() 
               .IsRequired();
    }
}
