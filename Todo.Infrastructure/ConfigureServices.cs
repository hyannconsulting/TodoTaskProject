using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Interfaces.Services;
using Todo.Infrastructure.Data;
using Todo.Infrastructure.Repositories;
using Todo.Infrastructure.Services;

namespace Todo.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));

            });

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoServices, TodoServices>();
            return services;    
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
            return services;
        }
    }
}