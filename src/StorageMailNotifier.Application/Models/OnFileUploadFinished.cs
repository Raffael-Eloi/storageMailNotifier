namespace StorageMailNotifier.Application.Models;

public class OnFileUploadFinished
{
    public OnFileUploadFinished()
    {
        BlobContent = string.Empty;
        FileName = string.Empty;
        BlobTrigger = string.Empty;
    }

    public string BlobContent { get; set; }

    public string FileName { get; set; }

    public string BlobTrigger { get; set; }

    public Uri? Uri { get; set; }
}