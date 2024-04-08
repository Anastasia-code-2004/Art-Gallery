using ArtGalleryApp.Entities;

namespace ArtGalleryApp.Pages;

public partial class MyProfilePage : ContentPage
{
	private readonly ArtGallery _artGallery;
	private Client _client;
	public MyProfilePage(ArtGallery artGallery)
	{
        
        InitializeComponent();
		_artGallery = artGallery;
		_client = (Client)_artGallery.GetCurrentUser();
		BindingContext = this;
        //NavigationPage.SetHasBackButton(this, false);
    }

	public Client Client
	{
		get => _client;
		set
		{
			_client = value;
			OnPropertyChanged(nameof(Client));
		}
	}
	private async void LogOutButton_OnClicked(object? sender, EventArgs e)
	{
		_artGallery.Logout(_client.Email, _client.Password);
        //await Shell.Current.Navigation.PopToRootAsync();
        Application.Current.MainPage = new AppShell();
        await Shell.Current.CurrentItem.Navigation.PushAsync(new NavigationPage(new LogInPage(_artGallery)));
        await Shell.Current.GoToAsync("//LogIn");
        //await Shell.Current.CurrentItem.CurrentItem.Navigation.PushAsync(new NavigationPage(new LogInPage(_artGallery)));
	}

    private async void BankCardButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BankCardPage(_artGallery));

    }
}