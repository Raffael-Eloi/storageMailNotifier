using StorageMailNotifier.Domain.Contracts.Repositories;
using System.Net;
using System.Net.Mail;

namespace StorageMailNotifier.Infrastructure.Repositories;

public class EmailRepository : IEmailRepository
{
    public async Task SendEmailAsync(MailMessage mail)
    {
        SmtpClient smtpClient = CreateSmtpClient();

        AddCredentials(smtpClient);

        EnableSSL(smtpClient);

        await SendEmail(smtpClient, mail);
    }

    private static SmtpClient CreateSmtpClient()
    {
        return new SmtpClient(
            host: "smtp.gmail.com", 
            port: 587
        );
    }

    private static void AddCredentials(SmtpClient smtpClient)
    {
        smtpClient.Credentials = new NetworkCredential("your-email@example.com", "your-email-password");
    }

    private static void EnableSSL(SmtpClient smtpClient)
    {
        smtpClient.EnableSsl = true;
    }

    private static async Task SendEmail(SmtpClient smtpClient, MailMessage mail)
    {
        await smtpClient.SendMailAsync(mail);
    }
}