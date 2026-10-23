using LinksApi.DTO.Links;

namespace LinksApi.Interfaces
{
    public interface ILinkService
    {
        Task<IEnumerable<LinkResponseDto>> GetLinks(int usuarioId);

        Task<LinkResponseDto?> GetLink(int id, int usuarioId);

        Task<LinkResponseDto?> CriarLink(LinkRequestDto request, int usuarioId);

        Task<LinkResponseDto?> AtualizarLink(int id, LinkRequestDto request, int usuarioId);

        Task<LinkResponseDto?> RemoverLink(int id, int usuarioId);
    }
}
