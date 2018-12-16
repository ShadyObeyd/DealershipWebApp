using Microsoft.AspNetCore.Builder;

namespace CarDealership.App.Middlewares
{
    public static class SeedMiddlewareExtensions
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedMiddleware>();
        }
    }
}