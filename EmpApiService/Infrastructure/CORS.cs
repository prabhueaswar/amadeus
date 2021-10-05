using EmpApiService.Common;
using EmpApiService.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpApiService.Infrastructure
{
    public static class CORS
    {
        internal static void ConfigureCORSService(this IServiceCollection services, IConfiguration configuration)
        {
            CorsSettings corsSettings = new CorsSettings();
            configuration.GetSection(Constants.CorsSettings).Bind(corsSettings);

            services.AddCors(options =>
            {
                options.AddPolicy(Constants.DefaultCorsPolicyName, builder =>
                {
                    builder.WithOrigins(corsSettings.Origins)
                    .WithMethods(corsSettings.Methods)
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }
    }
}
