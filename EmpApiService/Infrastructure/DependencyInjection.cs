using EmpApiService.DataAccess.Repositories;
using EmpApiService.DataAccess.Repositories.Interfaces;
using EmpApiService.Services;
using EmpApiService.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmpApiService.Infrastructure
{
    public static class DependencyInjection
    {
        internal static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddScoped<IUserService, UserService>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
