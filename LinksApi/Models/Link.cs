namespace LinksApi.Models
{
    public class Link
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public int CategoriaId { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
