using ADII.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ADII.SampleApp.EFExample;

//Modify the connection string extractor to be your correct if you are handling multiple connection strings across different contexts.
public class DatabaseContext : DbContext,
        IInjectable<DBContextDependencyInjector<ConnectionStringExtractor>>
{

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
    {
    }
}
