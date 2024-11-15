using MarsRoverPhotos.Data.Storage;
using MarsRoverPhotos.Domain;
using Microsoft.EntityFrameworkCore;

namespace MarsRoverPhotos.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options, IPhotoLoader photoLoader) : DbContext(options)
{
    public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Only used to generate the migration with the data
        //modelBuilder.Entity<Photo>().HasData(photoLoader.LoadPhotos());
    }
}