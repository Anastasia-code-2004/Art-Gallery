using ArtGalleryApp.Entities;
namespace ArtGalleryApp.Pages;

public partial class AddBankCardPage : ContentPage
{
	Client _client;
	public AddBankCardPage(Client client)
	{
		InitializeComponent();
		_client = client;

	}

    private async void OnAddCardClicked(object sender, EventArgs e)
    {
		_client.AddBankCard(CardNumberEntry.Text,  CVVEntry.Text, ExpirationDateEntry.Text);
		await Navigation.PopAsync(); 
    }
}