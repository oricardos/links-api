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


    }
}
