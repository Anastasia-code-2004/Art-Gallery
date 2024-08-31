using ArtGallerySystem.Domain.Services;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class AdminProfilePage : ContentPage
{
	public AdminProfilePage(AdminProfileViewModel adminProfileViewModel)
	{
		InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);
        BindingContext = adminProfileViewModel;
	}
    protected override bool OnBackButtonPressed()
    {
        UserService.SetCurrentUser(null);
        Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
        return true;
    }
}