using MarsRoverPhotos.Application.Services;
using MarsRoverPhotos.Data;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRoverPhotos.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddData();
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        services.AddServices();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPhotoService, PhotoService>();

        return services;
    }
}