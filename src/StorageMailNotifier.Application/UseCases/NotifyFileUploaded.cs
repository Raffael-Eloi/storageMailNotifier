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

    public async Task<NotifyFileUploadedResponse> NotifyAsync(OnFileUploadFinished request)
    {
        if (RequestIsInvalid(request, out ValidationResult validation))
        {
            return InvalidResponse(validation);
        }
        await NotifyEmail(request);

        return SuccessfulResponse();
    }

    private bool RequestIsInvalid(OnFileUploadFinished request, out ValidationResult validation)
    {
        validation = _validator.Validate(request);

        return !validation.IsValid;
    }
    
    private static NotifyFileUploadedResponse InvalidResponse(ValidationResult validation)
    {
        return new NotifyFileUploadedResponse(validation.Errors);
    }

    private static NotifyEmailRequest CreateNotifyRequest(OnFileUploadFinished request)
    {
        return new NotifyEmailRequest
        {
            BlobContent = request.BlobContent,
            FileName = request.FileName,
            BlobTrigger = request.BlobTrigger,
            OriginURL = request.Uri!.AbsoluteUri
        };
    }

    private async Task NotifyEmail(OnFileUploadFinished request)
    {
        NotifyEmailRequest notifyRequest = CreateNotifyRequest(request);

        await _emailServiceMock.NotifyAsync(notifyRequest);
    }

    private static NotifyFileUploadedResponse SuccessfulResponse()
    {
        return new NotifyFileUploadedResponse();
    }
}