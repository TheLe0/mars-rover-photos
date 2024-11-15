using MarsRoverPhotos.Application.DTO;

namespace MarsRoverPhotos.Application.Services;

public interface IPhotoService
{
    Task<PhotoContainerResponse> GetAllAsync(int pageNumber);
}
