namespace StorageMailNotifier.Domain.Models;

public class NotifyEmailRequest
{
    public NotifyEmailRequest()
    {
        BlobContent = string.Empty;    
    }

    public string BlobContent { get; set; }
}