using Microsoft.Azure.Functions.Worker;

namespace Blob.Storage.Listner.Functions;

public class OnFileUpload
{ 
    [Function("OnFileUpload")]
    public async Task Run([BlobTrigger("samples-workitems/{fileName}", Connection = "")] string content, string fileName, string blobTrigger, Uri uri)
    {
            var x = "";
    }
}