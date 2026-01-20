using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinksApi.Data;
using LinksApi.DTOs;
using LinksApi.Models;

namespace LinksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LinksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Controller funcionando");
        }


        //GET: api/links
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<LinkResponseDto>>>> GetLinks()
        {
            var links = await _context.Links
                .Select(l => new LinkResponseDto
                {
                    Id = l.Id,
                    Name = l.Name,
                    Url = l.Url,
                    Category = l.Category,
                }).ToListAsync();

            return Ok(ApiResponse<IEnumerable<LinkResponseDto>>.Ok(links));
        }

        //GET: api/links/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<LinkResponseDto>>> GetLink(int id)
        {
            var link = await _context.Links.FindAsync(id);

            if (link == null)
            {
                return NotFound(ApiResponse<LinkResponseDto>.Fail(new[] { "Link não encontrado" }));
            }

            return Ok(ApiResponse<LinkResponseDto>.Ok(new LinkResponseDto
            {
                Id = link.Id,
                Name = link.Name,
                Url = link.Url,
                Category = link.Category,
            }));
        }

        //POST: api/links
        [HttpPost]
        public async Task<ActionResult<ApiResponse<LinkResponseDto>>> CreateLink([FromBody] LinkCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<LinkResponseDto>.Fail(
                        ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                ));
            }

            var link = new Link
            {
                Name = dto.Name.Trim(),
                Url = dto.Url.Trim(),
                Category = dto.Category.Trim()
            };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLink), new { id = link.Id }, ApiResponse<LinkResponseDto>.Ok(
                new LinkResponseDto
                {
                    Id = link.Id,
                    Name = link.Name,
                    Url = link.Url,
                    Category = link.Category,
                }
            ));

        }

        //PUT: api/links/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> UpdateLink(int id, LinkUpdateDto dto)
        {
            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound(ApiResponse<string>.Fail(new[] { "Link não encontrado." }));
            }

            link.Name = dto.Name.Trim();
            link.Url = dto.Url.Trim();
            link.Category = dto.Category.Trim();

            await _context.SaveChangesAsync();

            return Ok(ApiResponse<string>.Ok("Atualizado com sucesso."));

        }

        //DELETE: api/link/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> DeleteLink(int id)
        {
            var link = await _context.Links.FindAsync(id);

            if (link == null)
            {
                return NotFound(ApiResponse<string>.Fail(new[] { "Link não encontrado." }));
            }

            _context.Links.Remove(link);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse<string>.Ok("Removido com sucesso."));
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedLinks(
            int page = 1,
            int pageSize = 10,
            string? category = null
            )
        {
            if (page <= 0 || pageSize <= 0)
            {
                return BadRequest(ApiResponse<LinkResponseDto>.Fail(new[] { "Parâmetros inválidos" }));
            }

            var query = _context.Links.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) && category != "Todas")
            {
                query = query.Where(l => l.Category == category);
            }

            var totalItems = await query.CountAsync();

            var links = await query
                .OrderByDescending(l => l.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var response = new PagedResponse<Link>
            {
                Success = true,
                Message = "Links Paginados",
                Data = links,
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };

            return Ok(response);
        }


    }
}