using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class CollectionPage : ContentPage
{
	CollectionViewModel collectionViewModel;
	public CollectionPage(CollectionViewModel collectionViewModel)
	{
		InitializeComponent();
		BindingContext = collectionViewModel;
		this.collectionViewModel = collectionViewModel;
	}
	protected async override void OnAppearing()
	{
        base.OnAppearing();
        await collectionViewModel.GetPaintingsAsync();
        //await Task.Run(async () => await collectionViewModel.GetPaintingsAsync());
        OnPropertyChanged(nameof(collectionViewModel.Paintings));
		
    }
}