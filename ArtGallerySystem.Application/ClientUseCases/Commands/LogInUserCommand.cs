namespace ArtGallerySystem.Application.ClientUseCases.Commands;

public sealed record LogInUserCommand(string EmailPhone, string Password) : IRequest<Client>
{}