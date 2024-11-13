namespace MarsRoverPhotos.Configuration;

public class DatabaseConfiguration
{
    public string ConnectionString { get; set; }

    public DatabaseConfiguration(string connectionString)
    {
        ConnectionString = connectionString;
    }
}