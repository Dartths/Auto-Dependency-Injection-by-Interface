using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ADII;

public class ScopedDependencyInjector : IDependecyInjector
{
    public void Inject(Type typeToInject, IServiceCollection services, IConfiguration configuration, Type interfaceType = null)
    {
        interfaceType ??= typeToInject.GetInterface($"I{typeToInject.Name}");
        if (interfaceType == null)
            throw new ApplicationException($"Could not find an interface for type {nameof(typeToInject)}");
        services.AddScoped(interfaceType, typeToInject);
    }
}