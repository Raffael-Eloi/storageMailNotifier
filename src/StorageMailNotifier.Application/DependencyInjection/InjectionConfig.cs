using Microsoft.Extensions.DependencyInjection;
using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.UseCases;

namespace StorageMailNotifier.Application.DependencyInjection;

public static class InjectionConfig
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<INotifyFileUploaded, NotifyFileUploaded>();
    }
}