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
        MailMessage mailMessage = CreateMailMessage(request);
        
        await SendEmail(mailMessage);
    }

    private static MailMessage CreateMailMessage(NotifyEmailRequest request)
    {
        return new MailMessage(
            from: GetMailFrom(),
            to: GetMailTo(),
            subject: GetSubject(),
            body: GetBody(request));
    }

    private static string GetMailFrom()
    {
        return "raffaeleloi.lab@gmail.com";
    }

    private static string GetMailTo()
    {
        return "raffaeleloi121@gmail.com";
    }

    private static string GetSubject()
    {
        return "A file has just been uploaded into your Azure AC container";
    }

    private static string GetBody(NotifyEmailRequest request)
    {
        return @$"
            The file {request.FileName} has been uploaded to your container.
            Blob trigger: {request.BlobTrigger}
            Origin URL: {request.OriginURL}
            
            Content: 
            {request.BlobContent}
        ";
    }

    private async Task SendEmail(MailMessage mailMessage)
    {
        await _emailRepository.SendEmailAsync(mailMessage);
    }
}