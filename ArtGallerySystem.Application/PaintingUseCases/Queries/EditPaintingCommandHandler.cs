using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.PaintingUseCases.Queries;

internal class EditPaintingCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<EditPaintingCommand, Painting>
{
    public async Task<Painting> Handle(EditPaintingCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.PaintingRepository.UpdateAsync(request.Painting, cancellationToken);
        await unitOfWork.SaveAllAsync();
        var updatedPainting = await unitOfWork.PaintingRepository.GetByIdAsync(request.Painting.Id, cancellationToken);
        return updatedPainting;
    }
}