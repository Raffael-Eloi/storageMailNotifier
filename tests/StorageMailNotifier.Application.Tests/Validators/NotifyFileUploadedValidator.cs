﻿using FluentValidation;
using StorageMailNotifier.Application.Models;

namespace StorageMailNotifier.Application.Tests.Validators;

internal class NotifyFileUploadedValidator : AbstractValidator<OnFileUploadFinished>
{
    public NotifyFileUploadedValidator()
    {
        RuleFor(fileUploaded => fileUploaded.BlobContent).NotEmpty();
        RuleFor(fileUploaded => fileUploaded.FileName).NotEmpty();
        RuleFor(fileUploaded => fileUploaded.BlobTrigger).NotEmpty();
        RuleFor(fileUploaded => fileUploaded.Uri).NotNull();
    }
}