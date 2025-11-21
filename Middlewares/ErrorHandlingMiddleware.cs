using System.Net;
using System.Text.Json;

namespace LinksApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var result = Json.Serialize(new
                {
                    success = false,
                    error = new[] { ex.Message }
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}