using ArtGallerySystem.Domain.Services;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
		BindingContext = profileViewModel;
	}
    protected override bool OnBackButtonPressed()
    {
        UserService.SetCurrentUser(null);
        Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
        return true;
    }
}