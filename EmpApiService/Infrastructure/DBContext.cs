using EmpApiService.Common;
using EmpApiService.Common.Configuration;
using EmpApiService.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmpApiService.Infrastructure
{
    public static class DBContext
    {
        internal static void ConfigureDBContextService(this IServiceCollection services, IConfiguration configuration)
        {
            var dbSettings = new ConnectionStringSettings();
            configuration.GetSection(Constants.ConnectionStringSettings).Bind(dbSettings);
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString(Constants.DataBaseContextName)));
        }

        internal static void ConfigureDBContext(this IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
            context.Database.Migrate();
        }
    }
}
