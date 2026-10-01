using LinksApi.DTO;
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

        [HttpPost]
        public async Task<IActionResult> CriarCategoria(CategoriaRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categoria = await _service.CriarCategoria(request);

            return Ok(categoria);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> AtualizarCategoria(FromBodyAttribute id, )
        //{
        //    var categoria = await _service.AtualizarCategoria(id);

        //    return Ok(categoria);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> RemoverCategoria(FromBodyAttribute id)
        //{
        //    var categoria = await _service.RemoverCategoria(id);
        //}
    }
}
