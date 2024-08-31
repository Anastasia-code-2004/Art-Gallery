using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.PaintingUseCases.Queries;

internal class DeletePaintingCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePaintingCommand, bool>
{
    public async Task<bool> Handle(DeletePaintingCommand request, CancellationToken cancellationToken)
    {
        var painting = await unitOfWork.PaintingRepository.GetByIdAsync(request.Id, cancellationToken);
        if(painting == null) return false;
        await unitOfWork.PaintingRepository.DeleteAsync(painting, cancellationToken);
        await unitOfWork.SaveAllAsync();
        return true;
    }
}