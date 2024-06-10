using StorageMailNotifier.Domain.Contracts.Repositories;
using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Models;
using System.Net.Mail;

namespace StorageMailNotifier.Domain.Tests.Services;

internal class EmailService : IEmailService
{
    private readonly IEmailRepository _emailRepository;

    public EmailService(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task NotifyAsync(NotifyEmailRequest request)
    {
        var mailMessage = new MailMessage(from: "raffaeleloi.lab@gmail.com", to: "raffaeleloi121@gmail.com", subject: "A file has just been uploaded into your Azure AC container", "");

        await _emailRepository.SendEmailAsync(mailMessage);
    }
}