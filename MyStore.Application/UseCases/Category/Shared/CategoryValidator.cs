using FluentValidation;
using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Category.Shared;

public class CategoryValidator : AbstractValidator<CategoryInputDto>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.CATEGORY_NAME_REQUIRED)
            .MaximumLength(100)
            .WithMessage(ResourceErrorMessages.CATEGORY_NAME_MAX_LENGTH);
    }
}
