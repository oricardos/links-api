using LinksApi.DTO.Usuarios;
using LinksApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LinksApi.Controllers.Usuarios
{
    [Route("api/Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetUsuarios();

            if (usuarios == null)
                return NotFound("Nenhum usuário foi encontrado!");

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuario(id);

            if (usuario == null)
                return NotFound("Nenhum usuário foi encontrado!");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuario = await _usuarioService.CriarUsuario(request);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, AtualizarUsuarioDto request)
        {
            var usuario = await _usuarioService.GetUsuario(id);

            if (usuario == null)
                return NotFound("Nenhum usuário foi encontrado com o id fornecido!");

            var updateUsuario = await _usuarioService.AtualizarUsuario(usuario.Id, request);

            return Ok(updateUsuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuario(id);

            if (usuario == null)
                return NotFound("Nenhum usuário foi encontrado com o id fornecido!");

            var removeUsuario = await _usuarioService.RemoverUsuario(id);

            return Ok(removeUsuario);
        }
    }
}
