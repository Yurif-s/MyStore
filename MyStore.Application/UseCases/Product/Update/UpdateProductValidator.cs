using FluentValidation;
using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Product.Update;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.PRODUCT_ID_INVALID);

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.PRODUCT_NAME_REQUIRED)
            .MaximumLength(200)
            .WithMessage(ResourceErrorMessages.PRODUCT_NAME_MAX_LENGTH);

        RuleFor(p => p.Price)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.PRODUCT_PRICE_INVALID);

        RuleFor(p => p.CategoryId)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.PRODUCT_CATEGORY_INVALID);
    }
}
