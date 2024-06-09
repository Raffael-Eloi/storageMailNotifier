using StorageMailNotifier.Domain.Models;

namespace StorageMailNotifier.Domain.Contracts.Services;

public interface IEmailService
{
    Task NotifyAsync(NotifyEmailRequest request);
}