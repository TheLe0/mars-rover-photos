namespace MarsRoverPhotos.Application.DTO;

public class PhotoContainerResponse
{
    public IEnumerable<PhotoResponse> Photos { get; set; }
    public int TotalSize { get; set; }
    public int NextPage { get; set; }
    public int PageSize { get; set; }
}
