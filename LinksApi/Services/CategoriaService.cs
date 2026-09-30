using LinksApi.Data;
using LinksApi.DTO;
using LinksApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinksApi.Services
{
    public class CategoriaService : ICategoriaService
    {
        private AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoriaResponseDto>> GetCategorias()
        {
            return await _context.Categorias
                .Select(c => new CategoriaResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Icon = c.Icon
                }).ToListAsync();
        }
    }
}
