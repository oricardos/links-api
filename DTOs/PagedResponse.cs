namespace LinksApi.DTOs
{
    public class PagedResponse<T>
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}