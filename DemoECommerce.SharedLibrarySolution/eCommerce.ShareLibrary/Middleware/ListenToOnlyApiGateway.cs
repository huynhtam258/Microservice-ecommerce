using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.ShareLibrary.Middleware
{
    public class ListenToOnlyApiGateway(RequestDelegate next, IHostEnvironment environment)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // Let local debugging and Swagger run without going through the gateway.
            if (environment.IsDevelopment() || context.Request.Path.StartsWithSegments("/swagger"))
            {
                await next(context);
                return;
            }

            var signedHeader = context.Request.Headers["Api-Getway"];

            if (signedHeader.FirstOrDefault() is null)
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("Sorry, service is unavailable");
                return;
            }

            await next(context);
        }
    }
}
