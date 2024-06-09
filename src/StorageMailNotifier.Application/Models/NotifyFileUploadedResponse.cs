using FluentValidation.Results;

namespace StorageMailNotifier.Application.Models;

public class NotifyFileUploadedResponse
{
    public NotifyFileUploadedResponse()
    {
        Errors = Enumerable.Empty<ValidationFailure>();    
    }

    public NotifyFileUploadedResponse(IEnumerable<ValidationFailure> errors)
    {
        Errors = errors;
    }

    public IEnumerable<ValidationFailure> Errors { get; set; }

    public bool IsValid => !Errors.Any();
}