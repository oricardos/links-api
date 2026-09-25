using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinksApi.Controllers.Categorias
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet("teste")]
        public IActionResult teste()
        {
            return Ok("Endpoint Categorias funcionando!");
        }
    }
}
