using Microsoft.AspNetCore.Mvc;
using WEBAPI.MODELSACCESS;

namespace WEBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GuardianController : ControllerBase
{
    
    private readonly ILogger<GuardianController> _logger;

    public GuardianController(ILogger<GuardianController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetGuardians")]
    public IEnumerable<Guardian> Get()
    {
       using (var context = new ModelContext())
        {
            return context.Guardians.ToList();
        }
    }
}
