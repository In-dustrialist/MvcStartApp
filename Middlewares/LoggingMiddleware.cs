using YourProjectNamespace.Data;
using YourProjectNamespace.Models.Db;

namespace YourProjectNamespace.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var logRepo = context.RequestServices.GetService<ILogRepository>();
            if (logRepo != null)
            {
                var request = new Request
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.UtcNow,
                    Url = context.Request.Path + context.Request.QueryString
                };

                await logRepo.LogRequest(request);
            }

            await _next(context);
        }
    }
}
