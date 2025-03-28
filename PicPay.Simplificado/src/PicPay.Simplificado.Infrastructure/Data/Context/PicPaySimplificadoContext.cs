using Microsoft.EntityFrameworkCore;
using PicPay.Simplificado.Domain.Entidades;
using System.Reflection;

namespace PicPay.Simplificado.Infrastructure.Data.Context;

public class PicPaySimplificadoContext : DbContext
{
    public DbSet<UsuarioComun> UsuarioComun { get; set; }
    public DbSet<UsuarioLojista> UsuarioLojista { get; set; }
    public DbSet<Transferencia> Transferencia { get; set; }

    public PicPaySimplificadoContext(DbContextOptions<PicPaySimplificadoContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
