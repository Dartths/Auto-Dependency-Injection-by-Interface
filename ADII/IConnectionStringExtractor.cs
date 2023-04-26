using Microsoft.Extensions.Configuration;

namespace ADII;

public interface IConnectionStringExtractor
{
    public string GetConnectionString(IConfiguration config);
}