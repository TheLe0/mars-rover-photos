namespace MarsRoverPhotos.Domain;

public class Photo
{
    public int Id { get; set; }
    public string Filename { get; set; }
    public string ImageUrl { get; set; }
    public DateTime Date { get; set; }
}