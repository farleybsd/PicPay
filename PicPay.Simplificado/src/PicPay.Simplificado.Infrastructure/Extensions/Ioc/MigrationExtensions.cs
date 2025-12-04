namespace PicPay.Simplificado.Infrastructure.Extensions.Ioc;

public static class MigrationExtensions
{
    public static void ApplyMigrations(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<PicPaySimplificadoContext>();

        db.Database.Migrate();
    }
}
