using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class AddExhibitionPage : ContentPage
{
	public AddExhibitionPage(AddExhibitionViewModel addExhibitionViewModel)
	{
		InitializeComponent();
		BindingContext = addExhibitionViewModel;
	}
}