using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ADII;

public static class DependencyInjectionHelper
{
    public static void InjectDependencies(IServiceCollection services,
        IConfiguration config,
        Assembly assembly = null)
    {
        assembly ??= Assembly.GetCallingAssembly();
        Inject(services, config, assembly, typeof(IInjectable<>));
        Inject(services, config, assembly, typeof(IInjectable<,>));
    }

    private static void Inject(IServiceCollection services, IConfiguration config, Assembly assembly, Type type)
    {
        var injectables = GetAllTypes(assembly, type);

        foreach (Type injectable in injectables)
        {
            var injectableInterface = injectable.GetInterfaces()
                .Single(x => x.IsGenericType &&
                    x.GetGenericTypeDefinition().Equals(type));

            // gets the lifetime
            var injectorType = injectableInterface
                .GetGenericArguments()
                .First();

            //gets the interface for the concrete class
            var interfaceType = injectableInterface
                .GetGenericArguments().Skip(1).FirstOrDefault();

            ((IDependecyInjector)Activator
                .CreateInstance(injectorType))
                .Inject(injectable, services, config, interfaceType);
        }
    }

    private static IEnumerable<Type> GetAllTypes(
        Assembly assembly,
        Type genericType,
        params Type[] genericParameterTypes)
    {
        if (!genericType.IsGenericTypeDefinition)
            throw new ArgumentException("Specified type must be a generic type definition.", nameof(genericType));

        var x = Assembly.GetCallingAssembly();
        return assembly
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition().Equals(genericType)));
    }
}
