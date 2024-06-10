using Microsoft.Extensions.DependencyInjection;
using StorageMailNotifier.Application.DependencyInjection;
using StorageMailNotifier.Domain.DependencyInjection;
using StorageMailNotifier.Infrastructure.DependencyInjection;

namespace StorageMailNotifier.Infrastructure.IoC;

public static class DependencyInjection
{
    public static void AddServicesDependencies(this IServiceCollection services)
    {
        services.AddApplicationDependencies();

        services.AddDomainDependencies();

        services.AddInfrastructureDependencies();
    }
}