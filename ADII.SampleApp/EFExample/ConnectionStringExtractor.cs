namespace ADII.SampleApp.EFExample;

//This is used to extract custom strings from application setings. Change the connection string for your custom implementation.
public class ConnectionStringExtractor : IConnectionStringExtractor
{
    public string GetConnectionString(IConfiguration config)
    {
        return config["ConnectionStrings:DatabaseConnection"];
    }
}