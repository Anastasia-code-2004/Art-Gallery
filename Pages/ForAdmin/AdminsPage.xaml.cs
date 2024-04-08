using ArtGalleryApp.Entities;	
namespace ArtGalleryApp.Pages.ForAdmin;

public partial class AdminsPage : ContentPage
{
    readonly ArtGallery _artGallery;
	public AdminsPage(ArtGallery artGallery)
	{
		InitializeComponent();
		_artGallery = artGallery;
        BindingContext = this;
        AdminsCollection.ItemsSource = _artGallery.GetAdmins();
	}
    protected override bool OnBackButtonPressed()
    {
        Navigation.PopAsync();
        return true;
    }
}