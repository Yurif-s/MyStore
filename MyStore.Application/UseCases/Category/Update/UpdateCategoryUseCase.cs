using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;
using MyStore.Application.UseCases.Category.Shared;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Category.Update;

public class UpdateCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IUpdateCategoryUseCase
{
    public async Task<Result<CategoryDto>> ExecuteAsync(int id, CategoryInputDto dto, CancellationToken ct = default)
    {
        var validationResult = await new CategoryValidator().ValidateAsync(dto, ct);
        if (!validationResult.IsValid)
            return Result<CategoryDto>.ValidationError(
                validationResult.Errors.Select(e => e.ErrorMessage));

        var category = await categoryRepository.GetByIdAsync(id);

        if (category is null)
            return Result<CategoryDto>.NotFound(ResourceErrorMessages.CATEGORY_NOT_FOUND);

        category.Update(dto.Name);

        categoryRepository.Update(category);
        await unitOfWork.CommitAsync(ct);

        var response = new CategoryDto(
            category.Name,
            category.Slug);

        return Result<CategoryDto>.Success(response);
}
}
