using ArtGallerySystem.Application.CategoryUseCases.Commands;
using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.CategoryUseCases.Queries;

internal class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if(category == null) return false;
        await unitOfWork.CategoryRepository.DeleteAsync(category, cancellationToken);
        await unitOfWork.SaveAllAsync();
        return true;
    }
}
