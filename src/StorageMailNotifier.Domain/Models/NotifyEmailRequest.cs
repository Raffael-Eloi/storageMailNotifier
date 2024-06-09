namespace StorageMailNotifier.Domain.Models;

public class NotifyEmailRequest
{
    public NotifyEmailRequest()
    {
        BlobContent = string.Empty;
        FileName = string.Empty;
        BlobTrigger = string.Empty;
        OriginURL = string.Empty;
    }

    public string BlobContent { get; set; }

    public string FileName { get; set; }

    public string BlobTrigger { get; set; }

    public string OriginURL { get; set; }
}