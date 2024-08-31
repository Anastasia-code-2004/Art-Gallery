using ArtGallerySystem.Application.ClientUseCases.Commands;

namespace ArtGallerySystem.Application.ClientUseCases.Queries;

internal class LogInUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<LogInUserCommand, Client>
{
    public async Task<Client> Handle(LogInUserCommand request, CancellationToken cancellationToken)
    {
        return await unitOfWork.ClientRepository.FirstOrDefaultAsync(client => (client.PersonalData.Email == request.EmailPhone 
                                                                               || client.PersonalData.Phone == request.EmailPhone) 
                                                                             && client.PersonalData.Password == request.Password, cancellationToken);
    }
}
