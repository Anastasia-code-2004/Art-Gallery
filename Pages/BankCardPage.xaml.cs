using ArtGalleryApp.Entities;


namespace ArtGalleryApp.Pages;

public partial class BankCardPage : ContentPage
{
	Client _client;
	public List<BankCard> _bankCards;
	private ArtGallery _artGallery;
	public BankCardPage(ArtGallery artGallery)
	{
		InitializeComponent();
		_artGallery = artGallery;
		_client = (Client)_artGallery.GetCurrentUser();
		_bankCards = (List<BankCard>)_artGallery.GetBankCardsByClientId(_client.ID);
		BindingContext = this;
		BankCardsCollection.ItemsSource = _bankCards;
	}

    private async void OnAddNewCardClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddBankCardPage(_client));
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        _bankCards = (List<BankCard>)_artGallery.GetBankCardsByClientId(_client.ID);
        BankCardsCollection.ItemsSource = _bankCards;
    }
}