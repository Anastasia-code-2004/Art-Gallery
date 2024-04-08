using ArtGalleryApp.Entities;
namespace ArtGalleryApp.Pages.ForAdmin;

public partial class ClientsPage : ContentPage
{
    private readonly ArtGallery _artGallery;
    public ClientsPage(ArtGallery artGallery)
	{
		InitializeComponent();
		_artGallery = artGallery;
        BindingContext = this;
        ClientsCollection.ItemsSource = _artGallery.GetClients();
    }

}