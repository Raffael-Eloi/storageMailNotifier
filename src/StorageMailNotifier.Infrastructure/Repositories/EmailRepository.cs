using Microsoft.Extensions.Configuration;
using StorageMailNotifier.Domain.Contracts.Repositories;
using System.Net;
using System.Net.Mail;

namespace StorageMailNotifier.Infrastructure.Repositories;

public class EmailRepository : IEmailRepository
{
    private readonly IConfiguration _configuration;

    public EmailRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

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

    private void AddCredentials(SmtpClient smtpClient)
    {
        smtpClient.UseDefaultCredentials = false;
        string email = _configuration["EmailSettings:Email"]!;
        string password = _configuration["EmailSettings:Password"]!;
        smtpClient.Credentials = new NetworkCredential(email, password);
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