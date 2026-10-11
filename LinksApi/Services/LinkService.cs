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

        public async Task<IEnumerable<LinkResponseDto>> GetLinks()
        {
            return await _context.Links
                .Select(l => new LinkResponseDto
                {
                    Id = l.Id,
                    Nome = l.Nome,
                    Url = l.Url,
                    CategoriaId = l.CategoriaId,
                    UsuarioId = l.UsuarioId
                }).ToListAsync();
        }

        public async Task<LinkResponseDto?> GetLink(int id)
        {
            return await _context.Links
                .Where(l => l.Id == id)
                .Select(l => new LinkResponseDto
                {
                    Id = l.Id,
                    Nome = l.Nome,
                    Url = l.Url,
                    CategoriaId = l.CategoriaId,
                    UsuarioId = l.UsuarioId
                }).FirstOrDefaultAsync();
        }

        public async Task<LinkResponseDto> CriarLink(LinkRequestDto request)
        {
            var link = new Link
            {
                Nome = request.Nome,
                Url = request.Url,
                CategoriaId = request.CategoriaId,
                UsuarioId = request.UsuarioId
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

        public async Task<LinkResponseDto> AtualizarLink(int id, LinkRequestDto request)
        {
            var link = await _context.Links
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();

            link.Nome = request.Nome;
            link.Url = request.Url;
            link.CategoriaId = request.CategoriaId;
            link.UsuarioId = request.UsuarioId;

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

        public async Task<LinkResponseDto?> RemoverLink(int id)
        {
            var link = await _context.Links.FindAsync(id);

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
