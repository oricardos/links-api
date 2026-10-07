using LinksApi.DTO;

namespace LinksApi.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaResponseDto>> GetCategorias();

        Task<CategoriaResponseDto> GetCategoria(int id);

        Task<CategoriaResponseDto> CriarCategoria(CategoriaRequestDto request);

        //Task<CategoriaResponseDto> AtualizarCategoria(int id);

        //Task<CategoriaResponseDto> RemoverCategoria(int id);
    }
}
