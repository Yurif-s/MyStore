using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Category.Delete;

public class DeleteCategoryUseCase(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IDeleteCategoryUseCase
{
    public async Task<Result> ExecuteAsync(int id, CancellationToken ct)
    {
        var category = await categoryRepository.GetByIdAsync(id, ct);

        if (category is null)
            return Result.NotFound(ResourceErrorMessages.CATEGORY_NOT_FOUND);

        categoryRepository.Remove(category);
        await unitOfWork.CommitAsync(ct);

        return Result.NoContent();
    }
}
