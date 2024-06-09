using FluentValidation.Results;
using StorageMailNotifier.Application.Contracts.UseCases;
using StorageMailNotifier.Application.Models;
using StorageMailNotifier.Application.Validators;
using StorageMailNotifier.Domain.Contracts.Services;
using StorageMailNotifier.Domain.Models;

namespace StorageMailNotifier.Application.UseCases;

public class NotifyFileUploaded : INotifyFileUploaded
{
    private readonly IEmailService _emailServiceMock;

    private readonly NotifyFileUploadedValidator _validator;

    public NotifyFileUploaded(
        IEmailService emailServiceMock, 
        NotifyFileUploadedValidator validator)
    {
        _emailServiceMock = emailServiceMock;
        _validator = validator;
    }

    public async Task NotifyAsync(OnFileUploadFinished request)
    {
        ValidationResult validation = _validator.Validate(request);

        if (!validation.IsValid) 
            return;

        var notifyRequest = new NotifyEmailRequest
        {
            BlobContent = request.BlobContent,
            FileName = request.FileName,
            BlobTrigger = request.BlobTrigger,
            OriginURL = request.Uri!.AbsoluteUri
        };

        await _emailServiceMock.NotifyAsync(notifyRequest);
    }
}