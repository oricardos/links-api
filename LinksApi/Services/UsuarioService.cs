using LinksApi.Data;
using LinksApi.DTO.Usuarios;
using LinksApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinksApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private AppDbContext _context;

        public UsuarioService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioResponseDto>> GetUsuarios()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioResponseDto
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    DataCriacao = u.DataCriacao,
                    Ativo = u.Ativo
                }).ToListAsync();
        }
    }
}
