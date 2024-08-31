using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class ExhibitionsPage : ContentPage
{
    readonly ExhibitionsViewModel exhibitionsViewModel;
	public ExhibitionsPage(ExhibitionsViewModel exhibitionsViewModel)
	{
		InitializeComponent();
        this.exhibitionsViewModel = exhibitionsViewModel;
		BindingContext = exhibitionsViewModel;
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await exhibitionsViewModel.GetExhibitionsAsync();
        //await Task.Run(async () => await collectionViewModel.GetPaintingsAsync());
        OnPropertyChanged(nameof(exhibitionsViewModel.Exhibitions));

    }
}