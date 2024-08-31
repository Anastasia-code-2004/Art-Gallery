using ArtGallerySystem.Application.AdminUseCases.Commands;

namespace ArtGallerySystem.Application.AdminUseCases.Queries;

internal class LogInUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<LogInUserCommand, Admin>
{
    public async Task<Admin> Handle(LogInUserCommand request, CancellationToken cancellationToken)
    {
        return await unitOfWork.AdminRepository.FirstOrDefaultAsync(admin => (admin.PersonalData.Email == request.EmailPhone 
                                                                              || admin.PersonalData.Phone == request.EmailPhone) 
                                                                             && admin.PersonalData.Password == request.Password);
    }
}