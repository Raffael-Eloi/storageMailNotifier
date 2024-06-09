using StorageMailNotifier.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace StorageMailNotifier.Application.Tests.Validators;

internal interface INotifyFileUploadedValidator
{
    ValidationResult Validate(OnFileUploadFinished request);
}