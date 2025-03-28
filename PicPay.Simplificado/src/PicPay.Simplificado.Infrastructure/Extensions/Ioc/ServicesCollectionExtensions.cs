namespace PicPay.Simplificado.Infrastructure.Extensions.Ioc;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddSqlServerDb(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Picpay");

        services.AddDbContext<PicPaySimplificadoContext>(options =>
            options.UseSqlServer(connectionString)
        );

        return services;
    }
}