using StorageMailNotifier.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace StorageMailNotifier.Application.Tests.Validators;

internal class NotifyFileUploadedValidatorShould
{
    [Test]
    public void Validate_Blob_Content()
    {
        #region Arrange(Given)

        var request = new OnFileUploadFinished();

        INotifyFileUploadedValidator validator = new NotifyFileUploadedValidator();

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        Assert.That(result, Is.Not.Null);

        Assert.That(result.ErrorMessage, Is.Not.Null);
        Assert.That(result.ErrorMessage, Is.EqualTo("The content is required"));

        #endregion
    }
}