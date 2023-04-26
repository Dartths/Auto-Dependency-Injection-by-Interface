using System;

namespace ADII;

///<Summary>
/// Implement this interface in order to remove the need of registering the services at startup.
/// TInjector defines the lifetime scope 
/// Only implement this for classes that implement the Foo : IFoo naming convention
///</Summary>
public interface IInjectable<TInjector> where TInjector : IDependecyInjector, new()
{

}

///<Summary>
/// Implement this interface in order to remove the need of registering the services at startup.
/// TInjector defines the lifetime scope . TInterface defines the interface to be injected.
///</Summary>
public interface IInjectable<TInjector, TInterface>
    where TInjector : IDependecyInjector, new()
    where TInterface : class
{

}