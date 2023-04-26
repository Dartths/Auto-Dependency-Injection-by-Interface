using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ADII;

public class ConfigDependencyInjector : IDependecyInjector
{
    public void Inject(Type typeToInject, IServiceCollection services, IConfiguration configuration, Type interfaceType = null)
    {
        IConfig config = (IConfig)Activator.CreateInstance(typeToInject);
        configuration.GetSection(config.SectionName).Bind(config);

        services.AddSingleton(typeToInject, config);
    }
}