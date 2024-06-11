using Microsoft.Extensions.DependencyInjection;
using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.UseCases;
using StorageMailNotifier.Application.Validators;

namespace StorageMailNotifier.Application.DependencyInjection;

public static class InjectionConfig
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        #region UseCases
        
        services.AddScoped<INotifyFileUploaded, NotifyFileUploaded>();

        #endregion

        #region Validators 

        services.AddScoped<NotifyFileUploadedValidator>();

        #endregion
    }
}