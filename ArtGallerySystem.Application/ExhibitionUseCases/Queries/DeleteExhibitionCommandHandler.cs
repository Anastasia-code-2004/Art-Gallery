using ArtGallerySystem.Application.ExhibitionUseCases.Commands;

namespace ArtGallerySystem.Application.ExhibitionUseCases.Queries;

internal class DeleteExhibitionCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteExhibitionCommand, bool>
{
    public async Task<bool> Handle(DeleteExhibitionCommand request, CancellationToken cancellationToken)
    {
        var exhibition = await unitOfWork.ExhibitionRepository.GetByIdAsync(request.Id, cancellationToken);
        if(exhibition == null) return false;
        await unitOfWork.ExhibitionRepository.DeleteAsync(exhibition, cancellationToken);
        await unitOfWork.SaveAllAsync();
        return true;
    }
}
