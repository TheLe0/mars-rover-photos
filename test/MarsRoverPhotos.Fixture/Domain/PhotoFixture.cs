using Bogus;
using MarsRoverPhotos.Domain;

namespace MarsRoverPhotos.Fixture.Domain;

public static class PhotoFixture
{
    public static Photo AutoGenerate()
    {
        return new Faker<Photo>()
            .RuleFor(u => u.Id, (f) => f.Random.Int())
            .RuleFor(u => u.ImageUrl, f => GenerateMarsImageUrl(f))
            .RuleFor(u => u.Filename, f => f.Random.String2(25, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"))
            .RuleFor(u => u.Date, f => f.Date.Past(1))
            .Generate();
    }

    public static IList<Photo> AutoGenerate(int numOfRecords)
    {
        return new Faker<Photo>()
            .RuleFor(u => u.Id, (f) => f.Random.Int())
            .RuleFor(u => u.ImageUrl, f => GenerateMarsImageUrl(f))
            .RuleFor(u => u.Filename, f => f.Random.String2(25, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"))
            .RuleFor(u => u.Date, f => f.Date.Past(1))
            .Generate(numOfRecords);
    }

    private static string GenerateMarsImageUrl(Faker f)
    {
        var imageId = f.Random.String2(25, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
        return $"http://mars.jpl.nasa.gov/msl-raw-images/msss/{f.Random.Int(1000, 2000)}/mrdi/{imageId}_DXXX.jpg";
    }
}
