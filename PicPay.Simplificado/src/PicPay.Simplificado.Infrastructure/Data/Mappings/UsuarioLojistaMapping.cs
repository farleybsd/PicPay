namespace PicPay.Simplificado.Infrastructure.Data.Mappings
{
    public class UsuarioLojistaMapping : IEntityTypeConfiguration<UsuarioLojista>
    {
        public void Configure(EntityTypeBuilder<UsuarioLojista> builder)
        {
            builder.HasKey(p => p.Id);

            // Mapping do Nome
            builder.OwnsOne(p => p.UsuarioNome, nome =>
            {
                nome.Property(n => n.NomeCompleto)
                    .HasMaxLength(60)
                    .IsRequired();
            });

            // Mapping do CNPJ
            builder.OwnsOne(p => p.UsuarioCnpj, cnpj =>
            {
                cnpj.Property(c => c.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(18) // formato 00.000.000/0000-00
                    .IsRequired();

                cnpj.HasIndex(c => c.Cnpj)
                    .IsUnique(); // CNPJ único
            });

            // Mapping do Email
            builder.OwnsOne(p => p.UsuarioEmail, email =>
            {
                email.Property(e => e.Email)
                     .HasColumnName("Email")
                     .HasMaxLength(100)
                     .IsRequired();

                email.HasIndex(e => e.Email)
                     .IsUnique(); // Email único
            });

            // Mapping do Saldo
            builder.OwnsOne(p => p.UsuarioSaldo, carteira =>
            {
                carteira.Property(c => c.Saldo)
                        .HasColumnName("Saldo")
                        .IsRequired();
            });

            // Mapping do StatusUsuario 
            builder.Property(p => p.StatusUsuario)
                   .HasConversion<string>()
                   .IsRequired();

            // Mapping do TipoUsuario 
            builder.Property(p => p.UsuarioCategoria)
                   .HasConversion<string>()
                   .IsRequired();
        }
    }
}