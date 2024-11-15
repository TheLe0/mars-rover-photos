using MarsRoverPhotos.Domain;

namespace MarsRoverPhotos.Data.Repositories;

public interface IPhotoRepository
{
    Task<IEnumerable<Photo>> GetAllAsync(int pageNumber = 1, int pageSize = 10);
    Task<int> GetTotalRecordsAsync();
}
