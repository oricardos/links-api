using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinksApi.Controllers.Links
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        [HttpGet("teste")]
        public IActionResult teste()
        {
            return Ok("Endpoint teste links funcionando!");
        }
    }
}
