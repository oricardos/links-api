using LinksApi.DTO;

namespace LinksApi.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaResponseDto>> GetCategorias();
    }
}
