using MarsRoverPhotos.Configuration;
using NasaApiClient.DTO;
using System.Text.Json;

namespace NasaApiClient;

public class NasaApiClient : INasaApiClient
{
    private readonly NasaConfiguration _configuration;
    private HttpClient _httpClient;

    public NasaApiClient(NasaConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = new HttpClient();
    }

    public async Task<IEnumerable<PhotoResponse>> GetPhotosByDateAsync(DateTime date)
    {
        var httpResponse = await _httpClient.GetAsync(_configuration.Url+"rovers/curiosity/photos?earth_date=" + date.ToString("yyyy-MM-dd") + "&api_key=" + _configuration.ApiKey);
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(httpResponse.ToString() + httpResponse.Content.ToString());
        }

        var content = await httpResponse.Content.ReadAsStringAsync();

        Console.WriteLine(content);

        var photoResponseContainer = JsonSerializer.Deserialize<PhotoContainerResponse>(content);
        var photos = photoResponseContainer?.Photos;

        return photos;
    }

}
