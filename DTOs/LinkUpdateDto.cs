using System.ComponentModel.DataAnnotations;

namespace LinksApi.DTOs
{
    public class LinkCreateDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
    }
}