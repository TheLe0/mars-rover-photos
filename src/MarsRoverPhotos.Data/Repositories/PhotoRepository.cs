using MarsRoverPhotos.Data.Context;
using MarsRoverPhotos.Domain;
using Microsoft.EntityFrameworkCore;

namespace MarsRoverPhotos.Data.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly AppDbContext _context;

    public PhotoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Photo>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
    {
        int skip = (pageNumber - 1) * pageSize;

        var photos = await _context.Photos
                             .OrderByDescending(p => p.Date) 
                             .Skip(skip) 
                             .Take(pageSize)
                             .ToListAsync();

        return photos;
    }

    public async Task<int> GetTotalRecordsAsync() => await _context.Photos.CountAsync();
}
