using FluentValidation.Results;
using StorageMailNotifier.Application.Models;

namespace StorageMailNotifier.Application.Tests.Validators;

internal class NotifyFileUploadedValidatorShould
{
    private NotifyFileUploadedValidator validator;

    private OnFileUploadFinished request;

    [SetUp]
    public void SetUp()
    {
        validator = new NotifyFileUploadedValidator();

        request = new OnFileUploadFinished
        {
            BlobContent = "my content",
            FileName = "my-file.txt",
            BlobTrigger = "mycontainer/my-file.txt",
            Uri = new Uri("https://something/text.txt")
        };
    }

    [Test]
    public void Validate_Blob_Content()
    {
        #region Arrange(Given)

        request.BlobContent = string.Empty;

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
    
    [Test]
    public void Validate_FileName()
    {
        #region Arrange(Given)

        request.FileName = string.Empty;

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        Assert.That(result.IsValid, Is.False);

        Assert.That(result.Errors.First().ErrorMessage, Is.EqualTo("'File Name' must not be empty."));

        #endregion
    }
}