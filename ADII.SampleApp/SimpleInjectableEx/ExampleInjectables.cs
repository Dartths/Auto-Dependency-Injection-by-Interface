namespace ADII.SampleApp.Controllers;


public interface ISingletonInjectable { }
public interface IScopedInjectable { }
public interface ITransientInjectable { }
public class TransientInjectable : ITransientInjectable, IInjectable<TransientDependencyInjector>
{
}

public class ScopedInjectable : IScopedInjectable, IInjectable<ScopedDependencyInjector>
{
}

public class SingletonInjectable : ISingletonInjectable, IInjectable<SingletonDependencyInjector>
{
}