using ArtGallerySystem.Application.MembershipUseCases.Commands;

namespace ArtGallerySystem.Application.MembershipUseCases.Queries;

internal class GetMembershipByClientIdRequestHandler(IUnitOfWork unitOfWork) 
    : IRequestHandler<GetMembershipByClientIdRequest, Membership>
{
    public async Task<Membership> Handle(GetMembershipByClientIdRequest request, CancellationToken cancellationToken)
    {
        //var membership =
        //    await unitOfWork.MembershipRepository.FirstOrDefaultAsync(t => t.ClientId == request.ClientId,
        //        cancellationToken);
        var m = await unitOfWork.MembershipRepository.ListAsync(t => t.ClientId == request.ClientId,
                cancellationToken, t => t.Client, t => t.CategoryMembership);
        return m.FirstOrDefault();
    }
}