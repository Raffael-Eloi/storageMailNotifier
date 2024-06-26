﻿using Blob.Storage.Listner.Functions;
using NSubstitute;
using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.Models;

namespace Blob.Storage.Listner.Tests.Functions;

internal class OnFileUploadShould
{
    private INotifyFileUploaded notifyFileUploadedMock;
    
    private OnFileUpload onFileUpload;

    [SetUp]
    public void SetUp()
    {
        notifyFileUploadedMock = Substitute.For<INotifyFileUploaded>();

        onFileUpload = new OnFileUpload(notifyFileUploadedMock);
    }

    [Test]
    public async Task Notify_When_Upload()
    {
        #region Arrange(Given)

        string content = "My content";
        string fileName = "my-file.txt";
        string blobTrigger = "mycontainer/my-file.txt";
        string url = "https://azure/storageaccount/mycontainer/my-file.txt";
        var uri = new Uri(url);

        #endregion

        #region Act(When)

        await onFileUpload.Run(content, fileName, blobTrigger, uri);

        #endregion

        #region Assert(Then)

        await notifyFileUploadedMock
            .Received()
            .NotifyAsync(Arg.Is<OnFileUploadFinished>(
                request => 
                    request.BlobContent == content &&
                    request.FileName == fileName &&
                    request.BlobTrigger == blobTrigger &&
                    request.Uri == uri
            ));

        #endregion
    }
}