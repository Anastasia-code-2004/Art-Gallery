namespace ArtGallerySystem.Application.AdminUseCases.Commands;

public sealed record LogInUserCommand(string EmailPhone, string Password) : IRequest<Admin>
{}
