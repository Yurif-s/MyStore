using FluentValidation;
using MyStore.Application.DTOs.Auth;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Auth.Login;

public class LoginUserValidation : AbstractValidator<LoginUserDto>
{
    public LoginUserValidation()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_REQUIRED)
            .EmailAddress()
            .WithMessage(ResourceErrorMessages.EMAIL_INVALID);

        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.PASSWORD_REQUIRED);
    }
}
