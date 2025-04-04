

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

    public static IServiceCollection AddCommand(this IServiceCollection services)
    {
        services.AddTransient<IUsuarioComunCommandHandler, UsuarioComunCommandHandler>();
        services.AddTransient<IUsuarioLojistaCommandHandler, UsuarioLojistaCommandHandler>();
        services.AddTransient<IQueryUsuarioComunAsync, QueryUsuarioComunAsync>();
        services.AddTransient<IQueryUsuarioLojistaAsync, QueryUsuarioLojistaAsync>();
        return services;
    }

    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddTransient<IUsuarioComumMapper, UsuarioComumMapper>();
        services.AddTransient<IUsuarioLojistaMapper, UsuarioLojistaMapper>();
        return services;
    }
}