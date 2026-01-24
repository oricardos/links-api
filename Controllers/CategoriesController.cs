using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinksApi.Data;
using LinksApi.DTOs;
using LinksApi.Models;

namespace LinksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Controller Funcionando");
        }

        //GET: api/categories
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CategoryResponseDto>>>> GetCategories()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Icon = c.Icon,
                }).ToListAsync();

            return Ok(ApiResponse<IEnumerable<CategoryResponseDto>>.Ok(categories));
        }
    }
}