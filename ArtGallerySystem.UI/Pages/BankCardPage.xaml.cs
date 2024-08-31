using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class BankCardPage : ContentPage
{
	BankCardViewModel bankCardViewModel;
	public BankCardPage(BankCardViewModel bankCardViewModel)
	{
		InitializeComponent();
		BindingContext = bankCardViewModel;
		this.bankCardViewModel = bankCardViewModel;
	}
	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await bankCardViewModel.UpdateBankCardsHandleAsync();
	}
}