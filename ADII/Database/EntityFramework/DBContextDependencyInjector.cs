using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ADII.Database.EntityFramework;

public class DBContextDependencyInjector<ConnectionStringExtractorT> : IDependecyInjector
    where ConnectionStringExtractorT : IConnectionStringExtractor, new()
{
    private static readonly MethodInfo _injectiongMethod;

    private static ConnectionStringExtractorT _connectionStringExtractor = new ConnectionStringExtractorT();

    static DBContextDependencyInjector()
    {
        _injectiongMethod = typeof(EntityFrameworkServiceCollectionExtensions).GetMethod("AddDbContext",
            1,
            new Type[] { typeof(IServiceCollection),
                typeof(Action<DbContextOptionsBuilder>),
                typeof(ServiceLifetime),
                typeof(ServiceLifetime)});
    }

    public void Inject(Type typeToInject, IServiceCollection services, IConfiguration config, Type interfaceType = null)
    {
        var genericMethod = _injectiongMethod.MakeGenericMethod(typeToInject);
        string connectionString = _connectionStringExtractor.GetConnectionString(config);
        Action<DbContextOptionsBuilder> optionsAction =
            options => options.UseSqlServer(connectionString)
                              .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

        genericMethod.Invoke(services, new object[] { services, optionsAction, ServiceLifetime.Scoped, ServiceLifetime.Scoped });
    }
}
