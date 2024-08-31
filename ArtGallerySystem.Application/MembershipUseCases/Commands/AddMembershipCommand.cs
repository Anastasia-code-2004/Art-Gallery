namespace ArtGallerySystem.Application.MembershipUseCases.Commands;

public sealed record AddMembershipCommand(int ClientId, int CategoryMembershipId, 
    DateTime StartDate, DateTime EndDate) : IRequest<Membership>
{
    
}