using EmpApiService.Common;
using EmpApiService.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EmpApiService.Infrastructure.Swagger
{
    public static class Swagger
    {
        internal static void ConfigureSwashbuckle(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerSettings = new SwaggerSettings();
            configuration.GetSection(Constants.SwaggerSettings).Bind(swaggerSettings);

            services.AddSwaggerGen((option) =>
            {
                option.SwaggerDoc(swaggerSettings.Version, new OpenApiInfo { Title = swaggerSettings.Title, Version = swaggerSettings.Version });
            });

        }

        internal static IApplicationBuilder UseSwashbuckle(this IApplicationBuilder app, IConfiguration config)
        {

            SwaggerSettings swaggerSettings = new SwaggerSettings();
            config.GetSection(Constants.SwaggerSettings).Bind(swaggerSettings);
            app.UseSwagger();

            app.UseSwaggerUI((option) =>
            {
                option.SwaggerEndpoint(swaggerSettings.EndPoint, swaggerSettings.Title);
            });

            return app;
        }
    }
}
