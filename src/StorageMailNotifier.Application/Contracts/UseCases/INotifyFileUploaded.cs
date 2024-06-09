using StorageMailNotifier.Application.Models;

namespace StorageMailNotifier.Application.Contracts.UseCases;

public interface INotifyFileUploaded
{
    Task<NotifyFileUploadedResponse> NotifyAsync(OnFileUploadFinished request);
}