using MarsRoverPhotos.Data;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRoverPhotos.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddData();
        
        return services;
    }
}