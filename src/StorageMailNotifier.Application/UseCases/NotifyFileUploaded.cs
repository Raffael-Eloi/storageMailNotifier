using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.Models;
using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Models;

namespace StorageMailNotifier.Application.UseCases;

public class NotifyFileUploaded : INotifyFileUploaded
{
    private IEmailService _emailServiceMock;

    public NotifyFileUploaded(IEmailService emailServiceMock)
    {
        _emailServiceMock = emailServiceMock;
    }

    public async Task NotifyAsync(OnFileUploadFinished request)
    {
        var notifyRequest = new NotifyEmailRequest
        {
            BlobContent = request.BlobContent,
            FileName = request.FileName,
        };

        await _emailServiceMock.NotifyAsync(notifyRequest);
    }
}