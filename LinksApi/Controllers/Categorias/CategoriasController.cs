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

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _service.GetCategorias();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _service.GetCategoria(id);

            if (categoria == null) return NotFound("Categoria não encontrada");

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCategoria(CategoriaRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categoria = await _service.CriarCategoria(request);

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCategoria(int id, CategoriaRequestDto request)
        {
            var categoria = await _service.GetCategoria(id);

            if (categoria == null) 
                return NotFound("Nenhuma categoria com o id fornecido foi encontrada");

            var updateCategoria = await _service.AtualizarCategoria(categoria.Id, request);

            return Ok(updateCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCategoria(int id)
        {
            var categoria = await _service.GetCategoria(id);

            if (categoria == null)
                return NotFound("Nenhuma categoria com o id fornecido foi encontrada");

            var removeCategoria = await _service.RemoverCategoria(id);

            return Ok(removeCategoria);
        }
    }
}
