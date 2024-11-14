using MarsRoverPhotos.Data.Extensions;
using MarsRoverPhotos.Domain;
using NasaApiClient;

namespace MarsRoverPhotos.Data.Storage;

public class PhotoLoader(INasaApiClient nasaApiClient) : IPhotoLoader
{
    private readonly INasaApiClient _nasaApiClient = nasaApiClient;

    public IEnumerable<Photo> LoadPhotos()
    {
        var photos = new List<Photo>();
        var dates = DateTimeExtension.GetDatesFromFile();

        foreach (var date in dates)
        {
            var photosResponse = _nasaApiClient.GetPhotosByDateAsync(date).Result;

            foreach (var photoDTO in photosResponse)
            {
                string fileName = Path.GetFileName(new Uri(photoDTO.ImageUrl).LocalPath);

                var photo = new Photo
                {
                    Id = photoDTO.Id,
                    Filename = fileName,
                    ImageUrl = photoDTO.ImageUrl,
                    Date = date
                };

                photos.Add(photo);
            }
        }

        return photos;
    }
}
