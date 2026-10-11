using LinksApi.DTO.Links;
using LinksApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinksApi.Controllers.Links
{
    [Route("api/[controller]")]
    [ApiController]
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
            var links = await _linkService.GetLinks();

            if (links == null)
                return NotFound("Nenhum link foi encontrado!");

            return Ok(links);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLink(int id)
        {
            var link = _linkService.GetLink(id);

            if (link == null)
                return NotFound("Nenhum link foi encontrado");

            return Ok(link);
        }

        [HttpPost]
        public async Task<IActionResult> CriarLink(LinkRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var link = await _linkService.CriarLink(request);

            return Ok(link);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLink(int id, LinkRequestDto request)
        {
            var link = await _linkService.AtualizarLink(id, request);

            if (link == null)
                return BadRequest();

            return Ok(link);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverLink(int id)
        {
            var link = await _linkService.GetLink(id);

            if (link == null)
                return NotFound("Nenhum link foi encontrado!");

            var removerLink = await _linkService.RemoverLink(id);

            return Ok(removerLink);
        }
    }
}
