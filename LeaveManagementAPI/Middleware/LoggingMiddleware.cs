namespace LeaveManagementAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"[REQUEST]  {context.Request.Method} {context.Request.Path} - {DateTime.Now}");

            await _next(context);

            Console.WriteLine($"[RESPONSE] Status: {context.Response.StatusCode} - {DateTime.Now}");
        }
    }
}