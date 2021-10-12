using Microsoft.AspNetCore.Mvc;
using BookCatalogueApi.Model;

namespace BookCatalogueApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public HealthStatus Get()
        {
            return new HealthStatus { Status = "healthy" };
        }
    }
}
