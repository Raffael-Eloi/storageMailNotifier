using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.Models;
using StorageMailNotifier.Domain.Contracts.Services;

namespace StorageMailNotifier.Application.UseCases;

public class NotifyFileUploaded : INotifyFileUploaded
{
    private IEmailService emailServiceMock;

    public NotifyFileUploaded(IEmailService emailServiceMock)
    {
        this.emailServiceMock = emailServiceMock;
    }

    public Task NotifyAsync(OnFileUploadFinished request)
    {
        throw new NotImplementedException();
    }
}