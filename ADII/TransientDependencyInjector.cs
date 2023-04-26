using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ADII;

public class TransientDependencyInjector : IDependecyInjector
{
    public void Inject(Type typeToInject, IServiceCollection services, IConfiguration configuration, Type interfaceType = null)
    {
        interfaceType ??= typeToInject.GetInterface($"I{typeToInject.Name}");
        if (interfaceType == null)
            throw new ApplicationException($"Could not find an interface for type {nameof(typeToInject)}");
        services.AddTransient(interfaceType, typeToInject);
    }
}
