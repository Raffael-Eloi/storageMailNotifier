using StorageMailNotifier.Domain.Contracts.Repositories;
using System.Net;
using System.Net.Mail;

namespace StorageMailNotifier.Infrastructure.Repositories;

public class EmailRepository : IEmailRepository
{
    public async Task SendEmailAsync(MailMessage mail)
    {
        var smtpClient = new SmtpClient(host: "smtp.gmail.com", port: 587);

        smtpClient.Credentials = new NetworkCredential("your-email@example.com", "your-email-password");
        smtpClient.EnableSsl = true;
        await smtpClient.SendMailAsync(mail);
    }
}