using System.ComponentModel.DataAnnotations;

namespace LinksApi.DTOs
{
    public class LinkUpdateDto
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [URL]
        [MaxLength(50)]
        public string Url { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }
    }
}