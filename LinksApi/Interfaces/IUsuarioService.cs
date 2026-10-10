using LinksApi.DTO.Usuarios;

namespace LinksApi.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioResponseDto>> GetUsuarios();
    }
}
