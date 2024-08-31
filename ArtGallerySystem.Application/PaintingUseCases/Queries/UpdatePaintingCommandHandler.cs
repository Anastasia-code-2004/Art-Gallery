using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.PaintingUseCases.Queries;

internal class UpdatePaintingCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdatePaintingCommand, Painting>
{
    public async Task<Painting> Handle(UpdatePaintingCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.PaintingRepository.UpdateAsync(request.Painting, cancellationToken);
        await unitOfWork.SaveAllAsync();

        return request.Painting;
    }
}
