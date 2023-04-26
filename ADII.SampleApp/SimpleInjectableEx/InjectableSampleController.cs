using Microsoft.AspNetCore.Mvc;

namespace ADII.SampleApp.Controllers;
[ApiController]
[Route("[controller]")]
public class InjectableController : ControllerBase
{
    private readonly ISingletonInjectable _singleton;
    private readonly IScopedInjectable _scoped;
    private readonly ITransientInjectable _transient;

    public InjectableController(ISingletonInjectable singleton, IScopedInjectable scoped, ITransientInjectable transient)
    {
        _singleton = singleton ?? throw new ArgumentNullException(nameof(singleton));
        _scoped = scoped ?? throw new ArgumentNullException(nameof(scoped));
        _transient = transient ?? throw new ArgumentNullException(nameof(transient));
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<string> Get()
    {
        return new List<string> { 
        $"{_singleton.GetType().FullName}",
        $"{_scoped.GetType().FullName}",
        $"{_transient.GetType().FullName}"
        };
    }
}
