using FluentValidation;
using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Product.Create;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.PRODUCT_NAME_REQUIRED)
            .MaximumLength(200)
            .WithMessage(ResourceErrorMessages.PRODUCT_NAME_MAX_LENGTH);

        RuleFor(p => p.Price)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.PRODUCT_PRICE_INVALID);

        RuleFor(p => p.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ResourceErrorMessages.PRODUCT_STOCK_INVALID);

        RuleFor(p => p.CategoryId)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.PRODUCT_CATEGORY_INVALID);
    }
}
