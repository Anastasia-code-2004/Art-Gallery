using ArtGallerySystem.Domain.Entities;

namespace ArtGallerySystem.Domain.Services;

public static class UserService
{
    private static Entity _currentUser;

    public static Entity GetCurrentUser()
    {
        return _currentUser;
    }

    public static void SetCurrentUser(Entity user)
    {
        _currentUser = user;
    }
}