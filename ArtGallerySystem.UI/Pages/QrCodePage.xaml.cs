using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class QrCodePage : ContentPage
{
	public QrCodePage(QrCodeViewModel qrCodeViewModel)
	{
		InitializeComponent();
		BindingContext = qrCodeViewModel;
	}
}