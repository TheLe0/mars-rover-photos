using System.Globalization;
using System.Reflection;

namespace MarsRoverPhotos.Data.Extensions;

public static class DateTimeExtension
{
    private static string[] dateFormats = new[]
    {
        "MM/dd/yy",
        "MMMM d, yyyy",
        "MMM-dd-yyyy",
        "MMMM dd, yyyy"
    };

    public static List<DateTime> GetDatesFromFile()
    {
        List<DateTime> dates = new List<DateTime>();
        DateTime dateValue;
        string line;

        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "wwwroot", "dates.txt");
        FileStream fileStream = new FileStream(path, FileMode.Open);
        using (StreamReader reader = new StreamReader(fileStream))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (DateTime.TryParseExact(line, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                {
                    dates.Add(dateValue);
                }
                else
                {
                    Console.WriteLine("The date '{0}' is invalid!", line);
                }
            }
        }
        fileStream.Close();
        fileStream.Dispose();

        return dates;
    }
}
