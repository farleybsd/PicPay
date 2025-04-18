﻿namespace PicPay.Simplificado.Infrastructure.Data.Mappings
{
    public class UsuarioComumMapping : IEntityTypeConfiguration<UsuarioComun>
    {
        public void Configure(EntityTypeBuilder<UsuarioComun> builder)
        {
            builder.HasKey(p => p.Id);

            // Mapping do Nome
            builder.OwnsOne(p => p.UsuarioNome, nome =>
            {
                nome.Property(n => n.NomeCompleto)
                //.HasColumnName("NomeCompleto") // <-- aqui define o nome da coluna No Banco
                    .HasMaxLength(60)
                    .IsRequired();
            });

            // Mapping do CPF
            builder.OwnsOne(p => p.UsuarioCpf, cpf =>
            {
                cpf.Property(c => c.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(14)
                    .IsRequired();

                cpf.HasIndex(c => c.Cpf)
                    .IsUnique(); // Garante CPF único
            });

            // Mapping do Email
            builder.OwnsOne(p => p.UsuarioEmail, email =>
            {
                email.Property(e => e.Email)
                     .HasColumnName("Email")
                     .HasMaxLength(100)
                     .IsRequired();

                email.HasIndex(e => e.Email)
                     .IsUnique(); // Garante Email único
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

            // Mapping do Password
            builder.OwnsOne(p => p.UsuarioPassword, password =>
            {
                password.Property(pw => pw.PasswordHash)
                        .HasColumnName("PasswordHash")
                        .HasMaxLength(500)
                        .IsRequired();

                password.Property(pw => pw.Salt)
                        .HasColumnName("Salt")
                        .HasMaxLength(100)
                        .IsRequired();
            });
        }
    }
}