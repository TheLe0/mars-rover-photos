using NasaApiClient.DTO;

namespace NasaApiClient;

public interface INasaApiClient
{
    Task<IEnumerable<PhotoResponse>> GetPhotosByDateAsync(DateTime date);
}
