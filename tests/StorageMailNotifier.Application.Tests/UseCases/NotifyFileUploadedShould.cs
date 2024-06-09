using NSubstitute;
using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.Models;
using StorageMailNotifier.Application.UseCases;
using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Models;

namespace StorageMailNotifier.Application.Tests.UseCases;

internal class NotifyFileUploadedShould
{
    [Test]
    public async Task Notify_Content()
    {
        #region Arrange(Given)

        string content = "My content";

        var request = new OnFileUploadFinished
        {
            BlobContent = content,
        };

        var emailServiceMock = Substitute.For<IEmailService>();

        INotifyFileUploaded notifyFileUploaded = new NotifyFileUploaded(emailServiceMock);

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
}