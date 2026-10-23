using LinksApi.DTO.Links;
using LinksApi.Interfaces;
using LinksApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinksApi.Controllers.Links
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LinksController : ControllerBase
    {
        private readonly ILinkService _linkService;

        public LinksController(ILinkService linkService)
        {
            _linkService = linkService;
        }
    

        [HttpGet]
        public async Task<IActionResult> GetLinks()
        {
            var usuarioIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (usuarioIdClaim == null)
                return Unauthorized();

            var usuarioId = int.Parse(usuarioIdClaim);

            var links = await _linkService.GetLinks(usuarioId);

            return Ok(links);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLink(int id)
        {
            var usuarioIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (usuarioIdClaim == null)
                return Unauthorized();

            var usuarioId = int.Parse(usuarioIdClaim);

            var link = await _linkService.GetLink(id, usuarioId);

            if (link == null)
                return NotFound("Nenhum link foi encontrado");

            return Ok(link);
        }

        [HttpPost]
        public async Task<IActionResult> CriarLink(LinkRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuarioIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (usuarioIdClaim == null)
                return Unauthorized();

            var usuarioId = int.Parse(usuarioIdClaim);

            var link = await _linkService.CriarLink(request, usuarioId);

            if (link == null)
                return BadRequest("A categoria informada não existe ou não pertence ao usuário.");

            return Ok(link);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLink(int id, LinkRequestDto request)
        {
            var usuarioIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (usuarioIdClaim == null)
                return Unauthorized();

            var usuarioId = int.Parse(usuarioIdClaim);

            var link = await _linkService.AtualizarLink(id, request, usuarioId);

            if (link == null)
                return BadRequest("A categoria informada não existe ou não pertence ao usuário.");

            return Ok(link);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverLink(int id)
        {
            var usuarioIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (usuarioIdClaim == null)
                return Unauthorized();

            var usuarioId = int.Parse(usuarioIdClaim);

            var removerLink = await _linkService.RemoverLink(id, usuarioId);

            if (removerLink == null)
                return NotFound("Nenhum link foi encontrado!");

            return Ok(removerLink);
        }
    }
}
