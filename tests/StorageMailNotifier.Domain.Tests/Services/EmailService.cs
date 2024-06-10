using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Models;

namespace StorageMailNotifier.Domain.Tests.Services;

internal class EmailService : IEmailService
{
    public Task NotifyAsync(NotifyEmailRequest request)
    {
        throw new NotImplementedException();
    }
}