using NSubstitute;
using StorageMailNotifier.Domain.Contracts.Repositories;
using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Models;
using StorageMailNotifier.Domain.Services;
using System.Net.Mail;

namespace StorageMailNotifier.Domain.Tests.Services;

internal class EmailServiceShould
{
    private IEmailRepository emailRepositoryMock;
    
    private IEmailService emailService;
    
    private NotifyEmailRequest request;

    [SetUp]
    public void SetUp()
    {
        emailRepositoryMock = Substitute.For<IEmailRepository>();

        emailService = new EmailService(emailRepositoryMock);
        
        request = new NotifyEmailRequest();
    }

    [Test]
    public async Task Send_Email_With_From_Information()
    {
        #region Arrange(Given)

        string from = "raffaeleloi.lab@gmail.com";

        #endregion

        #region Act(When)

        await emailService.NotifyAsync(request);

        #endregion

        #region Assert(Then)

        await emailRepositoryMock
            .Received()
            .SendEmailAsync(Arg.Is<MailMessage>(
                mailMessage => 
                    mailMessage.From!.Address == from)
            );

        #endregion
    }
    
    [Test]
    public async Task Send_Email_With_To_Information()
    {
        #region Arrange(Given)

        string to = "raffaeleloi121@gmail.com";

        #endregion

        #region Act(When)

        await emailService.NotifyAsync(request);

        #endregion

        #region Assert(Then)

        await emailRepositoryMock
            .Received()
            .SendEmailAsync(Arg.Is<MailMessage>(
                mailMessage => 
                    mailMessage.To.First().Address == to)
            );

        #endregion
    }
    
    [Test]
    public async Task Send_Email_With_Subject_Information()
    {
        #region Arrange(Given)

        string subject = "A file has just been uploaded into your Azure AC container";

        #endregion

        #region Act(When)

        await emailService.NotifyAsync(request);

        #endregion

        #region Assert(Then)

        await emailRepositoryMock
            .Received()
            .SendEmailAsync(Arg.Is<MailMessage>(
                mailMessage => 
                    mailMessage.Subject == subject)
            );

        #endregion
    }
    
    [Test]
    public async Task Send_Email_With_Body_Information()
    {
        #region Arrange(Given)

        request = new NotifyEmailRequest
        {
            BlobContent = "This is the file content",
            FileName = "my-file.txt",
            BlobTrigger = "container/my-file.txt",
            OriginURL = "https:originurl.com"
        };

        string body = @$"
            The file {request.FileName} has been uploaded to your container.
            Blob trigger: {request.BlobTrigger}
            Origin URL: {request.OriginURL}
            
            Content: 
            {request.BlobContent}
        ";

        #endregion

        #region Act(When)

        await emailService.NotifyAsync(request);

        #endregion

        #region Assert(Then)

        await emailRepositoryMock
            .Received()
            .SendEmailAsync(Arg.Is<MailMessage>(
                mailMessage => 
                    mailMessage.Body == body)
            );

        #endregion
    }
}