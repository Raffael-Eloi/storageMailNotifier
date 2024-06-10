using Microsoft.Azure.Functions.Worker;
using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.Models;

namespace Blob.Storage.Listner.Functions;

public class OnFileUpload
{
    private INotifyFileUploaded _notifyFileUploaded;

    public OnFileUpload(INotifyFileUploaded notifyFileUploaded)
    {
        _notifyFileUploaded = notifyFileUploaded;
    }

    [Function("OnFileUpload")]
    public async Task Run([BlobTrigger("samples-workitems/{fileName}", Connection = "")] 
        string content, 
        string fileName, 
        string blobTrigger, 
        Uri uri)
    {
        OnFileUploadFinished request = CreateRequest(content, fileName, blobTrigger, uri);
        
        await NotifyFileUploaded(request);
    }

    private static OnFileUploadFinished CreateRequest(string content, string fileName, string blobTrigger, Uri uri)
    {
        return new OnFileUploadFinished
        {
            BlobContent = content,
            FileName = fileName,
            BlobTrigger = blobTrigger,
            Uri = uri
        };
    }

    private async Task NotifyFileUploaded(OnFileUploadFinished request)
    {
        await _notifyFileUploaded.NotifyAsync(request);
    }
}