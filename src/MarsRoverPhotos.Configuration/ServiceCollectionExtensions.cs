using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRoverPhotos.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var nasaConfig = configuration.GetSection("NasaApi").Get<NasaConfiguration>();
        services.AddSingleton(nasaConfig);

        var appConfig = configuration.GetSection("AppConfig").Get<AppConfiguration>();
        services.AddSingleton(appConfig);

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var databaseConfig = new DatabaseConfiguration(connectionString);
        services.AddSingleton(databaseConfig);
        
        return services;
    }
}