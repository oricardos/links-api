using LinksApi.Data;
using LinksApi.DTO.Links;
using LinksApi.Interfaces;
using LinksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksApi.Services
{
    public class LinkService : ILinkService
    {
        private AppDbContext _context;

        public LinkService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LinkResponseDto>> GetLinks(int usuarioId)
        {
            return await _context.Links
                .Where(l => l.UsuarioId == usuarioId)
                .Select(l => new LinkResponseDto
                {
                    Id = l.Id,
                    Nome = l.Nome,
                    Url = l.Url,
                    CategoriaId = l.CategoriaId,
                    UsuarioId = l.UsuarioId
                }).ToListAsync();
        }

        public async Task<LinkResponseDto?> GetLink(int id, int usuarioId)
        {
            var link = await _context.Links
                .Where(l => l.Id == id && l.UsuarioId == usuarioId)
                .Select(l => new LinkResponseDto
                {
                    Id = l.Id,
                    Nome = l.Nome,
                    Url = l.Url,
                    CategoriaId = l.CategoriaId,
                    UsuarioId = l.UsuarioId
                }).FirstOrDefaultAsync();

            if (link == null)
                return null;

            return link;
        }

        public async Task<LinkResponseDto?> CriarLink(LinkRequestDto request, int usuarioId)
        {
            var categoriaExiste = await _context.Categorias
                .AnyAsync(c => c.Id == request.CategoriaId && c.UsuarioId == usuarioId);

            if (!categoriaExiste)
                return null;

            var link = new Link
            {
                Nome = request.Nome,
                Url = request.Url,
                CategoriaId = request.CategoriaId,
                UsuarioId = usuarioId
            };

            _context.Add(link);

            await _context.SaveChangesAsync();

            return new LinkResponseDto
            {
                Id = link.Id,
                Nome = link.Nome,
                Url = link.Url,
                CategoriaId = link.CategoriaId,
                UsuarioId = link.UsuarioId
            };
        }

        public async Task<LinkResponseDto?> AtualizarLink(int id, LinkRequestDto request, int usuarioId)
        {
            var categoriaExiste = await _context.Categorias
                .AnyAsync(c => c.Id == request.CategoriaId && c.UsuarioId == usuarioId);

            if (!categoriaExiste)
                return null;

            var link = await _context.Links
                .Where(l => l.Id == id && l.UsuarioId == usuarioId)
                .FirstOrDefaultAsync();

            if (link == null)
                return null;

            link.Nome = request.Nome;
            link.Url = request.Url;
            link.CategoriaId = request.CategoriaId;
            link.UsuarioId = usuarioId;

            await _context.SaveChangesAsync();

            return new LinkResponseDto
            {
                Id = link.Id,
                Nome = link.Nome,
                Url = link.Url,
                CategoriaId = link.CategoriaId,
                UsuarioId = link.UsuarioId
            };
        }

        public async Task<LinkResponseDto?> RemoverLink(int id, int usuarioId)
        {
            var link = await _context.Links
                .Where(l => l.Id == id && l.UsuarioId == usuarioId)
                .FirstOrDefaultAsync();

            if (link == null)
                return null;

            _context.Remove(link);

            await _context.SaveChangesAsync();

            return new LinkResponseDto
            {
                Id = link.Id,
                Nome = link.Nome,
                Url = link.Url,
                CategoriaId = link.CategoriaId,
                UsuarioId = link.UsuarioId
            };
        }
    }
}
