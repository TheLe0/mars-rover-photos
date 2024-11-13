using MarsRoverPhotos.Configuration;
using MarsRoverPhotos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRoverPhotos.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var dbConfig = services.BuildServiceProvider().GetRequiredService<DatabaseConfiguration>();
            options.UseSqlite(dbConfig.ConnectionString);
        });
        
        return services;
    }
}