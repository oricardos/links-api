using LinksApi.Data;
using LinksApi.DTO;
using LinksApi.Interfaces;
using LinksApi.Models;
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

        public async Task<CategoriaResponseDto> CriarCategoria(CategoriaRequestDto request)
        {
            var categoria = new Categoria
            {
                Name = request.Name,
                Icon = request.Icon
            };

            _context.Add(categoria);

            await _context.SaveChangesAsync();

            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Name = categoria.Name,
                Icon = categoria.Icon
            };
        }

        //public Task<CategoriaResponseDto> AtualizarCategoria(int id)
        //{

        //}

        //public Task<CategoriaResponseDto> RemoverCategoria(int id)
        //{
        //    var categoria = _context.Categorias
        //        .Where(c =>
        //        {
        //            c.Id = id
        //        })
        //        .Remove();
        //}
    }
}
