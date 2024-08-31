using System.Net.Sockets;
using ArtGallerySystem.Application.CategoryUseCases.Commands;

namespace ArtGallerySystem.Application.CategoryUseCases.Queries;

internal class AddCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCategoryCommand, Category>
{
    public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name, request.Description, request.Discount);
        await unitOfWork.CategoryRepository.AddAsync(category, cancellationToken);
        await unitOfWork.SaveAllAsync();
        category = await unitOfWork.CategoryRepository.GetByIdAsync(category.Id, cancellationToken);
        return category;
    }
}
