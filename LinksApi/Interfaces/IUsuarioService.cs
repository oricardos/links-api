using LinksApi.DTO.Usuarios;

namespace LinksApi.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioResponseDto>> GetUsuarios();

        Task<UsuarioResponseDto> GetUsuario(int id);

        Task<UsuarioResponseDto> CriarUsuario(UsuarioRequestDto request);

        Task<UsuarioResponseDto> AtualizarUsuario(int id, AtualizarUsuarioDto request);

        Task<UsuarioResponseDto> RemoverUsuario(int id);
    }
}
