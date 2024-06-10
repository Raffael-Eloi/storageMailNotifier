using Microsoft.Extensions.DependencyInjection;
using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Services;

namespace StorageMailNotifier.Domain.DependencyInjection;

public static class InjectionConfig
{
    public static void AddDomainDependencies(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
    }
}