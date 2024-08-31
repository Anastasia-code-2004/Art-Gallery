using ArtGallerySystem.Application.ExhibitionUseCases.Commands;

namespace ArtGallerySystem.Application.ExhibitionUseCases.Queries;

internal class EditExhibitionCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<EditExhibitionCommand, Exhibition>
{
    public async Task<Exhibition> Handle(EditExhibitionCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.ExhibitionRepository.UpdateAsync(request.Exhibition, cancellationToken);
        await unitOfWork.SaveAllAsync();
        var updatedExhibition = await unitOfWork.ExhibitionRepository.GetByIdAsync(request.Exhibition.Id, cancellationToken);
        return updatedExhibition;
    }
}

