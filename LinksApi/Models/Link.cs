namespace LinksApi.Models
{
    public class Link
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Url { get; set; }

        public int CategoriaId { get; set; }
    }
}
