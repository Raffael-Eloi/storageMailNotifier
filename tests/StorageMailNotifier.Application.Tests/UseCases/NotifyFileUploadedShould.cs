using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.Models;
using StorageMailNotifier.Application.UseCases;
using StorageMailNotifier.Application.Validators;
using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Models;

namespace StorageMailNotifier.Application.Tests.UseCases;

internal class NotifyFileUploadedShould
{
    private IEmailService emailServiceMock;

    private NotifyFileUploadedValidator validatorMock;

    private INotifyFileUploaded notifyFileUploaded;

    private OnFileUploadFinished request;

    [SetUp]
    public void SetUp()
    {
        emailServiceMock = Substitute.For<IEmailService>();

        validatorMock = Substitute.For<NotifyFileUploadedValidator>();

        notifyFileUploaded = new NotifyFileUploaded(
            emailServiceMock,
            validatorMock);

        request = new OnFileUploadFinished
        {
            Uri = new Uri("https://something/text.txt")
        };

        validatorMock
            .Validate(request)
            .ReturnsForAnyArgs(new ValidationResult());
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

    [Test]
    public async Task Notify_With_BlobTrigger()
    {
        #region Arrange(Given)

        string blobTrigger = "mycontainer/my-file.txt";
        request.BlobTrigger = blobTrigger;

        #endregion

        #region Act(When)

        await notifyFileUploaded.NotifyAsync(request);

        #endregion

        #region Assert(Then)

        await emailServiceMock
            .Received()
            .NotifyAsync(Arg.Is<NotifyEmailRequest>(
                req =>
                    req.BlobTrigger == blobTrigger));

        #endregion
    }

    [Test]
    public async Task Notify_With_Requested_URL()
    {
        #region Arrange(Given)

        string url = "https://azure/storageaccount/mycontainer/my-file.txt";
        request.Uri = new Uri(url);

        #endregion

        #region Act(When)

        await notifyFileUploaded.NotifyAsync(request);

        #endregion

        #region Assert(Then)

        await emailServiceMock
            .Received()
            .NotifyAsync(Arg.Is<NotifyEmailRequest>(
                req =>
                    req.OriginURL == url));

        #endregion
    }

    [Test]
    public async Task Validate_When_Notify()
    {
        #region Arrange(Given)

        var validationFailure = new ValidationFailure("propertyName", "errorMessage");

        var validationFailures = new List<ValidationFailure>
        {
            validationFailure 
        };

        var validationResult = new ValidationResult(validationFailures);

        validatorMock
            .Validate(request)
            .ReturnsForAnyArgs(validationResult);

        #endregion

        #region Act(When)

        NotifyFileUploadedResponse response = await notifyFileUploaded.NotifyAsync(request);

        #endregion

        #region Assert(Then)

        await emailServiceMock
            .DidNotReceive()
            .NotifyAsync(Arg.Any<NotifyEmailRequest>());

        Assert.That(response.IsValid, Is.False);

        #endregion
    }
}