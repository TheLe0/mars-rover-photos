using MarsRoverPhotos.Configuration;
using MarsRoverPhotos.Data.Context;
using MarsRoverPhotos.Data.Repositories;
using MarsRoverPhotos.Data.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NasaApiClient;

namespace MarsRoverPhotos.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddNasaClient();
        services.AddStorage();

        services.AddDbContext<AppDbContext>(options =>
        {
            var dbConfig = services.BuildServiceProvider().GetRequiredService<DatabaseConfiguration>();
            options.UseSqlite(dbConfig.ConnectionString);
        });

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddStorage(this IServiceCollection services)
    {
        services.AddScoped<IPhotoLoader, PhotoLoader>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPhotoRepository, PhotoRepository>();

        return services;
    }
}