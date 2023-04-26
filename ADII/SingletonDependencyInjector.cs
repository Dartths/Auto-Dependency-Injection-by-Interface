using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ADII;

public class SingletonDependencyInjector : IDependecyInjector
{
    public void Inject(Type typeToInject, IServiceCollection services, IConfiguration config, Type interfaceType = null)
    {
        interfaceType ??= typeToInject.GetInterface($"I{typeToInject.Name}");
        if (interfaceType == null)
            throw new ApplicationException($"Could not find an interface for type {nameof(typeToInject)}");
        services.AddSingleton(interfaceType, typeToInject);
    }
}
