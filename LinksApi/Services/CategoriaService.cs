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
        public async Task<IEnumerable<CategoriaResponseDto>> GetCategorias(int usuarioId)
        {
            return await _context.Categorias
                .Where(c => c.UsuarioId == usuarioId)
                .Select(c => new CategoriaResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Icon = c.Icon
                }).ToListAsync();
        }

        public async Task<CategoriaResponseDto?> GetCategoria(int id, int usuarioId)
        {
            return await _context.Categorias
                .Where(c => c.Id == id && c.UsuarioId == usuarioId)
                .Select(c => new CategoriaResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Icon = c.Icon
                }).FirstOrDefaultAsync();
        }

        public async Task<CategoriaResponseDto> CriarCategoria(CategoriaRequestDto request, int usuarioId)
        {
            var categoria = new Categoria
            {
                Name = request.Name,
                Icon = request.Icon,
                UsuarioId = usuarioId
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

        public async Task<CategoriaResponseDto> AtualizarCategoria(int id, CategoriaRequestDto request, int usuarioId)
        {
            var categoria = await _context.Categorias
                .Where(c => c.Id == id && c.UsuarioId == usuarioId)
                .FirstOrDefaultAsync();

            categoria.Name = request.Name;
            categoria.Icon = request.Icon;

            await _context.SaveChangesAsync();

            return new CategoriaResponseDto
            {
                Id = id,
                Name = categoria.Name,
                Icon = categoria.Icon
            };
        }

        public async Task<CategoriaResponseDto?> RemoverCategoria(int id, int usuarioId)
        {
            var categoria = await _context.Categorias
                .Where(c => c.Id == id && c.UsuarioId == usuarioId)
                .FirstOrDefaultAsync();

            if (categoria == null)
            {
                return null;
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return new CategoriaResponseDto 
            {
                Id = categoria.Id, 
                Name = categoria.Name, 
                Icon = categoria.Icon
            };
        }
    }
}
