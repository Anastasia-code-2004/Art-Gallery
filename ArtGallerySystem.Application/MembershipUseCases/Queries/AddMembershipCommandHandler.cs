using ArtGallerySystem.Application.MembershipUseCases.Commands;

namespace ArtGallerySystem.Application.MembershipUseCases.Queries;

internal class AddMembershipCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddMembershipCommand, Membership>
{
    public async Task<Membership> Handle(AddMembershipCommand request, CancellationToken cancellationToken)
    {
        var membership = new Membership(request.ClientId, request.CategoryMembershipId, 
            request.StartDate, request.EndDate);
        await unitOfWork.MembershipRepository.AddAsync(membership, cancellationToken);
        await unitOfWork.SaveAllAsync();
        membership = await unitOfWork.MembershipRepository.GetByIdAsync(membership.Id, cancellationToken);
        return membership;
    }
}

