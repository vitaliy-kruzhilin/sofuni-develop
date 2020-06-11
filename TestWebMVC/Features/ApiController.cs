using Microsoft.AspNetCore.Mvc;

namespace TestWebMVC.Features
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
