using NSubstitute;
using StorageMailNotifier.Domain.Contracts.Repositories;
using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Models;
using System.Net.Mail;

namespace StorageMailNotifier.Domain.Tests.Services;

internal class EmailServiceShould
{
    [Test]
    public async Task Send_Email_With_From_Information()
    {
        #region Arrange(Given)

        var request = new NotifyEmailRequest();

        var emailRepositoryMock = Substitute.For<IEmailRepository>();

        IEmailService emailService = new EmailService(emailRepositoryMock);

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
}