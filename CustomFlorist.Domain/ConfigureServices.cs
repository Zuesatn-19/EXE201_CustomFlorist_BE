using CustomFlorist.Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFlorist.Domain;

public static class ConfigureServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CustomFloristContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                builder => builder.MigrationsAssembly(typeof(CustomFloristContext).Assembly.FullName));
        });
        return services;
    }
}