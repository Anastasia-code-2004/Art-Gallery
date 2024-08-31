using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.PaintingUseCases.Queries;

internal class AddPaintingCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddPaintingCommand, Painting>
{
    public async Task<Painting> Handle(AddPaintingCommand request, CancellationToken cancellationToken)
    {
        var painting = new Painting(request.Name, request.Author, request.YearOfCreation, request.Description, request.Photo);
        await unitOfWork.PaintingRepository.AddAsync(painting, cancellationToken);
        await unitOfWork.SaveAllAsync();
        painting = await unitOfWork.PaintingRepository.GetByIdAsync(painting.Id, cancellationToken);
        return painting;
    }
}
