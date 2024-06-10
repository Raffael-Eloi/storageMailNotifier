using Microsoft.Extensions.DependencyInjection;
using StorageMailNotifier.Domain.Contracts.Repositories;
using StorageMailNotifier.Infrastructure.Repositories;

namespace StorageMailNotifier.Infrastructure.DependencyInjection;

public static class InjectionConfig
{
    public static void AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<IEmailRepository, EmailRepository>();
    }
}