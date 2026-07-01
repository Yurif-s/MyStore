using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Category.Create;

public class CreateCategoryUseCase(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : ICreateCategoryUseCase
{
    public async Task<Result<CategoryDto>> ExecuteAsync(CategoryInputDto dto, CancellationToken ct = default)
    {
        var validationResult = await new CreateCategoryValidator().ValidateAsync(dto, ct);
        if (!validationResult.IsValid)
            return Result<CategoryDto>.ValidationError(
                validationResult.Errors.Select(e => e.ErrorMessage));

        var categoryExist = await categoryRepository.ExistsByNameAsync(dto.Name, ct);

        if (categoryExist is true)
            return Result<CategoryDto>.ValidationError(ResourceErrorMessages.CATEGORY_ALREADY_EXISTS);

        Domain.Entities.Category category = new(dto.Name);

        await categoryRepository.AddAsync(category, ct);
        await unitOfWork.CommitAsync(ct);

        var response = new CategoryDto(
            category.Name,
            category.Slug);

        return Result<CategoryDto>.Success(response);
    }
}
