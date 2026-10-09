namespace LinksApi.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
