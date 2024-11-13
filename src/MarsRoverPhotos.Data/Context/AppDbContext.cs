using MarsRoverPhotos.Domain;
using Microsoft.EntityFrameworkCore;

namespace MarsRoverPhotos.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Photo> Photos { get; set; }
}