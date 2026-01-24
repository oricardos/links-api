using System.ComponentModel.DataAnnotations;

namespace LinksApi.DTOs
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}