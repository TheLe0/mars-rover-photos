using MarsRoverPhotos.Data.Extensions;

namespace MarsRoverPhotos.UnitTest.Data;

public static class DateTimeExtensionTest
{
    [Fact]
    public static void GetDatesFromFile_Should_FindDates()
    {
        var dates = DateTimeExtension.GetDatesFromFile();

        Assert.NotNull(dates);
        Assert.NotEmpty(dates);
        Assert.Equal(3, dates.Count);
    }
}
