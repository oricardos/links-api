using System.ComponentModel.DataAnnotations;

namespace LinksApi.DTOs
{
    public class LinkCreateDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required(ErrorMessage = "A URL é obrigatória.")]
        [Url(ErrorMessage = "A URL precisa ser válida.")]
        [MaxLength(2000)]
        public string Url { get; set; }

        [Required(ErrorMessage = "A Categoria é obrigatória")]
        [MaxLength(50)]
        public string Category { get; set; }
    }
}