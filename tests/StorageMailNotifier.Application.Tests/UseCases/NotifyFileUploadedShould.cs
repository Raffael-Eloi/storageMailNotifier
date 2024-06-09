using NSubstitute;
using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.Models;
using StorageMailNotifier.Application.UseCases;
using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Models;

namespace StorageMailNotifier.Application.Tests.UseCases;

internal class NotifyFileUploadedShould
{
    private IEmailService emailServiceMock;
    
    private INotifyFileUploaded notifyFileUploaded;
    
    private OnFileUploadFinished request;

    [SetUp]
    public void SetUp()
    {
        emailServiceMock = Substitute.For<IEmailService>();

        notifyFileUploaded = new NotifyFileUploaded(emailServiceMock);

        request = new OnFileUploadFinished();
    }

    [Test]
    public async Task Notify_With_Content()
    {
        #region Arrange(Given)

        string content = "My content";
        request.BlobContent = content;

        #endregion

        #region Act(When)

        await notifyFileUploaded.NotifyAsync(request);

        #endregion

        #region Assert(Then)

        await emailServiceMock
            .Received()
            .NotifyAsync(Arg.Is<NotifyEmailRequest>(
                req => 
                    req.BlobContent == content));

        #endregion
    }
    
    [Test]
    public async Task Notify_With_FileName()
    {
        #region Arrange(Given)

        string filename = "my-file.txt";
        request.FileName = filename;

        #endregion

        #region Act(When)

        await notifyFileUploaded.NotifyAsync(request);

        #endregion

        #region Assert(Then)

        await emailServiceMock
            .Received()
            .NotifyAsync(Arg.Is<NotifyEmailRequest>(
                req => 
                    req.FileName == filename));

        #endregion
    }
}