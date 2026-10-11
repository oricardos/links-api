namespace LinksApi.DTO.Links
{
    public class LinkRequestDto
    {
        public string Nome { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public int CategoriaId { get; set; }

        public int UsuarioId { get; set; }
    }
}
