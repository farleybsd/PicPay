using PicPay.Simplificado.Application.Handler.Transferencia;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;

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
        services.AddTransient<ITransferenciaCommandHandler, TransferenciaCommandHandler>();
        services.AddTransient<ITransferenciaEntreUsuariosCommandHandler, TransferenciaEntreUsuariosCommandHandler>();
        return services;
    }

    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddTransient<IUsuarioComumMapper, UsuarioComumMapper>();
        services.AddTransient<IUsuarioLojistaMapper, UsuarioLojistaMapper>();
        services.AddTransient<ITransferenciaMapper, TransferenciaMapper>();
        return services;
    }
}