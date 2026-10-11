using LinksApi.DTO.Links;

namespace LinksApi.Interfaces
{
    public interface ILinkService
    {
        Task<IEnumerable<LinkResponseDto>> GetLinks();

        Task<LinkResponseDto> GetLink(int id);

        Task<LinkResponseDto> CriarLink(LinkRequestDto request);

        Task<LinkResponseDto> AtualizarLink(int id, LinkRequestDto request);

        Task<LinkResponseDto> RemoverLink(int id);
    }
}
