using CustomFlorist.Domain.Persistance;
using CustomFlorist.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFlorist.Repository;

public static class ConfigureServices
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork<CustomFloristContext>, UnitOfWork<CustomFloristContext>>();
        return services;
    }
}