using StorageMailNotifier.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace StorageMailNotifier.Application.Tests.Validators;

internal class NotifyFileUploadedValidator : INotifyFileUploadedValidator
{
    public ValidationResult Validate(OnFileUploadFinished request)
    {
        throw new NotImplementedException();
    }
}