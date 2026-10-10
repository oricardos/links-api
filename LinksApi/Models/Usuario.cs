namespace LinksApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; } = string.Empty;

        public string SenhaHash { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public bool Ativo { get; set; } = true;

        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();

        public ICollection<Link> Links { get; set; } = new List<Link>();
    }
}
