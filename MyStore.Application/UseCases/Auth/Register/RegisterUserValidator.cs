using FluentValidation;
using MyStore.Application.DTOs.Auth;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Auth.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.FullName)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.FULLNAME_REQUIRED)
            .MaximumLength(100)
            .WithMessage(ResourceErrorMessages.FULLNAME_MAX_LENGTH);

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_REQUIRED)
            .EmailAddress()
            .WithMessage(ResourceErrorMessages.EMAIL_INVALID);

        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.PASSWORD_REQUIRED)
            .MinimumLength(8)
            .WithMessage(ResourceErrorMessages.PASSWORD_MIN_LENGTH);
    }
}
