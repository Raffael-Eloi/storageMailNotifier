using System.Net.Mail;

namespace StorageMailNotifier.Domain.Contracts.Repositories;

public interface IEmailRepository
{
    Task SendEmailAsync(MailMessage mail);
}