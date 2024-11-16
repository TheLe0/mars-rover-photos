using Bogus;
using MarsRoverPhotos.Configuration;

namespace NasaApiClient.Configuration;

public static class AppConfigurationFixture
{
    public static AppConfiguration AutoGenerate()
    {
        return new Faker<AppConfiguration>()
            .RuleFor(u => u.PageSize, (f) => f.Random.Int())
            .Generate();
    }
}
