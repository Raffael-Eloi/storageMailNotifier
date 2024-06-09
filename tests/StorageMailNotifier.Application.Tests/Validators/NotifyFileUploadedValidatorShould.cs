using FluentValidation.Results;
using StorageMailNotifier.Application.Models;

namespace StorageMailNotifier.Application.Tests.Validators;

internal class NotifyFileUploadedValidatorShould
{
    [Test]
    public void Validate_Blob_Content()
    {
        #region Arrange(Given)

        var request = new OnFileUploadFinished();

        var validator = new NotifyFileUploadedValidator();

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        Assert.That(result, Is.Not.Null);

        Assert.That(result.IsValid, Is.False);
        Assert.That(result.Errors.First().ErrorMessage, Is.EqualTo("'Blob Content' must not be empty."));

        #endregion
    }
}