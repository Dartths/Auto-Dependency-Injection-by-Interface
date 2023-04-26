using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ADII.SampleApp.EFExample;
[Route("api/[controller]")]
[ApiController]
public class EFExampleController : ControllerBase
{
    private readonly DatabaseContext _context;

    public EFExampleController(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet]
    public string Get()
    {
        return $"Can connect to  Database: {_context.Database.CanConnect()}";
    }
}
