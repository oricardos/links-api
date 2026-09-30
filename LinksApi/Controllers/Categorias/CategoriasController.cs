using LinksApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinksApi.Controllers.Categorias
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet("teste")]
        public IActionResult teste()
        {
            return Ok("Endpoint Categorias funcionando!");
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _service.GetCategorias();

            return Ok(categorias);
        }
    }
}
