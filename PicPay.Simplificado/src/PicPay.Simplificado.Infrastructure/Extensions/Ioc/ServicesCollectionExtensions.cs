using PicPay.Simplificado.Application.Handler;
using PicPay.Simplificado.Application.Mapper;
using PicPay.Simplificado.Application.Mapper.Interface;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands;
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

    public static IServiceCollection AddCommand(this IServiceCollection services)
    {
        services.AddTransient<IUsuarioComunCommandHandler, UsuarioComunCommandHandler>();
        return services;
    }

    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddTransient<IUsuarioComumMapper, UsuarioComumMapper>();
        return services;
    }
}