using System.ComponentModel.DataAnnotations;

namespace LinksApi.DTOs
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Ícone é obrigatório")]
        public string Icon { get; set; }
    }
}