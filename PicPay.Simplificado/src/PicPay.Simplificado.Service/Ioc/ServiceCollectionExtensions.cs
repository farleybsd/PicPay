namespace PicPay.Simplificado.Service.Ioc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicoAutorizacao(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<LoggingAuthorizeHandler>();
        services.AddSingleton<IValidateOptions<AuthorizeSettings>, AuthorizeSettingsValidate>();
        services.AddOptionsWithValidateOnStart<AuthorizeSettings>()
            .Bind(configuration.GetSection("Providers:Authorize"))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddTransient<AuthorizeGateway>();

        services.AddHttpClient<IAuthorizeGateway, AuthorizeGateway>((serviceProvider, httpClient) =>
        {
            var viaCepSettings = serviceProvider.GetRequiredService<IOptions<AuthorizeSettings>>();
            httpClient.BaseAddress = new(viaCepSettings.Value.BaseAddress);
            Console.WriteLine($"BaseAddress configurada corretamente: {httpClient.BaseAddress}");
        }).AddHttpMessageHandler<LoggingAuthorizeHandler>();

        return services;
    }
}