using System;

namespace LinksApi.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public static ApiResponse<T> Ok(T data) => new ApiResponse<T> { Success = true, Data = data };

        public static ApiResponse<T> Fail(IEnumerable<string> errors) => new ApiResponse<T> { Success = false, Errors = errors };
    }
}