using LinksApi.DTO;

namespace LinksApi.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaResponseDto>> GetCategorias(int usuarioId);

        Task<CategoriaResponseDto> GetCategoria(int id, int usuarioId);

        Task<CategoriaResponseDto> CriarCategoria(CategoriaRequestDto request);

        Task<CategoriaResponseDto> AtualizarCategoria(int id, CategoriaRequestDto request);

        Task<CategoriaResponseDto?> RemoverCategoria(int id);
    }
}
