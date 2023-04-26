using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ADII;
public interface IDependecyInjector
{
    public void Inject(Type typeToInject, IServiceCollection services, IConfiguration config, Type interfaceType = null);
}