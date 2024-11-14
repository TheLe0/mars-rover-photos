using Microsoft.Extensions.DependencyInjection;

namespace NasaApiClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNasaClient(this IServiceCollection services)
    {
        services.AddScoped<INasaApiClient, NasaApiClient>();

        return services;
    }
}
