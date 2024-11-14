using System.Text.Json.Serialization;

namespace NasaApiClient.DTO;

public class PhotoResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("img_src")]
    public string ImageUrl { get; set; }
}