using System.Text.Json.Serialization;

namespace NasaApiClient.DTO;

public class PhotoContainerResponse
{
    [JsonPropertyName("photos")]
    public List<PhotoResponse> Photos { get; set; }
}
