using ArtGallerySystem.Application.ClientUseCases.Commands;
using ArtGallerySystem.Application.ExhibitionUseCases.Commands;

namespace ArtGallerySystem.Application.ExhibitionUseCases.Queries;

internal class AddExhibitionCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddExhibitionCommand, Exhibition>
{
    public async Task<Exhibition> Handle(AddExhibitionCommand request, CancellationToken cancellationToken)
    {
        var exhibition = new Exhibition(request.Name, request.Description, request.StartDate, request.EndDate,
            request.TicketPrice);
        await unitOfWork.ExhibitionRepository.AddAsync(exhibition, cancellationToken);
        await unitOfWork.SaveAllAsync();
        exhibition = await unitOfWork.ExhibitionRepository.GetByIdAsync(exhibition.Id, cancellationToken);
        return exhibition;
    }
}

