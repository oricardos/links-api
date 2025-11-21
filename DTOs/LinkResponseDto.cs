using System.ComponentModel.DataAnnotations;

namespace LinksApi.DTOs
{
    public class LinkResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
    }
}