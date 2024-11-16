using MarsRoverPhotos.Data.Storage;
using MarsRoverPhotos.Fixture.NasaApiClient;
using Moq;
using NasaApiClient;

namespace MarsRoverPhotos.UnitTest.Storage;

public class PhotoLoaderTest
{
    private readonly Mock<INasaApiClient> _nasaApiClient;
    private readonly IPhotoLoader _loader;

    public PhotoLoaderTest()
    {
        _nasaApiClient = new Mock<INasaApiClient>();
        _loader = new PhotoLoader(_nasaApiClient.Object);
    }

    [Fact]
    public void LoadPhotos_Should_ReturnPhotoList()
    {
        var photoResponse = PhotoResponseFixture.AutoGenerate(3);

        _nasaApiClient
            .Setup(client => client.GetPhotosByDateAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(photoResponse);

        var result = _loader.LoadPhotos();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(9, result.Count());
    }
}
