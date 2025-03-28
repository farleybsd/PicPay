using PicPay.Simplificado.Infrastructure.Data.UOfWork;

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

    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITransfereneciaRepositorio, TransferenciaRepositorio>();
        services.AddScoped<IUsuarioComunRepositorio, UsuarioComunRepositorio>();
        services.AddScoped<IUsuarioLojistaRepositorio, UsuarioLojistaRepositorio>();
        return services;
    }
}