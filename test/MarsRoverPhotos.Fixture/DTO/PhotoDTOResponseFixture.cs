using Bogus;
using MarsRoverPhotos.Application.DTO;

namespace MarsRoverPhotos.Fixture.DTO;

public class PhotoDTOResponseFixture
{
    public static PhotoResponse AutoGenerate()
    {
        return new Faker<PhotoResponse>()
            .RuleFor(u => u.ImageUrl, f => GenerateMarsImageUrl(f))
            .Generate();
    }

    public static IList<PhotoResponse> AutoGenerate(int numOfRecords)
    {
        return new Faker<PhotoResponse>()
            .RuleFor(u => u.ImageUrl, f => GenerateMarsImageUrl(f))
            .Generate(numOfRecords);
    }

    private static string GenerateMarsImageUrl(Faker f)
    {
        var imageId = f.Random.String2(25, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
        return $"http://mars.jpl.nasa.gov/msl-raw-images/msss/{f.Random.Int(1000, 2000)}/mrdi/{imageId}_DXXX.jpg";
    }
}
