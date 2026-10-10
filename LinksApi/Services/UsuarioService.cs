using LinksApi.Data;
using LinksApi.DTO.Usuarios;
using LinksApi.Interfaces;
using LinksApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LinksApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private AppDbContext _context;
        private readonly PasswordHasher<Usuario> _passwordHasher = new();

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

        public async Task<UsuarioResponseDto?> GetUsuario(int id)
        {
            return await _context.Usuarios
                .Where(u => u.Id == id)
                .Select(u => new UsuarioResponseDto
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    DataCriacao = u.DataCriacao,
                    Ativo = u.Ativo
                }).FirstOrDefaultAsync();
        }

        public async Task<UsuarioResponseDto> CriarUsuario(UsuarioRequestDto request)
        {
            var usuario = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email
            };

            usuario.SenhaHash = _passwordHasher.HashPassword(usuario, request.Senha);

            _context.Usuarios.Add(usuario);

            await _context.SaveChangesAsync();

            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataCriacao = usuario.DataCriacao,
                Ativo = usuario.Ativo
            };
        }

        public async Task<UsuarioResponseDto> AtualizarUsuario(int id, AtualizarUsuarioDto request)
        {
            var usuario = await _context.Usuarios
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            usuario.Nome = request.Nome;
            usuario.Email = request.Email;

            await _context.SaveChangesAsync();

            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataCriacao = usuario.DataCriacao,
                Ativo = usuario.Ativo
            };
        }

        public async Task<UsuarioResponseDto?> RemoverUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return null;

            usuario.Ativo = false;
            await _context.SaveChangesAsync();

            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataCriacao = usuario.DataCriacao,
                Ativo = usuario.Ativo
            };
        }
    }
}
