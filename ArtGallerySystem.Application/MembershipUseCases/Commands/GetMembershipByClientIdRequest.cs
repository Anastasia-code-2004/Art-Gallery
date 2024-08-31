namespace ArtGallerySystem.Application.MembershipUseCases.Commands;

public sealed record GetMembershipByClientIdRequest(int ClientId) : IRequest<Membership>
{
    
}