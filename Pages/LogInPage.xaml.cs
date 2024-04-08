using ArtGalleryApp.Entities;
using ArtGalleryApp.Pages.ForAdmin;
using ArtGalleryApp.Services;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;


namespace ArtGalleryApp.Pages;

public partial class LogInPage : ContentPage
{
    public LogInPage(ArtGallery artGallery)
    {
        InitializeComponent();
        _artGallery = artGallery;
        BindingContext = this;
    }

    private readonly ArtGallery _artGallery;
    private string _login;
    private string _password;
    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged(nameof(Login));
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    private async void LogInButton_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            _artGallery.Login(Login, Password);
            if(Login == "admin")
            {
                Application.Current.MainPage = new AdminShell();
                
                //await Navigation.PushAsync(new NavigationPage(new AdminProfilePage(_artGallery)));
                await Shell.Current.CurrentItem.Navigation.PushAsync(new NavigationPage(new AdminProfilePage(_artGallery)));
                await Shell.Current.GoToAsync("//AdminProfile");
                //await Shell.Current.GoToAsync("//AdminProfile");
                //await Shell.Current.CurrentItem.CurrentItem.Navigation.PushAsync(new NavigationPage(new AdminProfilePage(_artGallery)));
                //await Navigation.PushAsync(new AdminProfilePage(_artGallery));
            }
            else
            {
                //await Shell.Current.GoToAsync("//AdminProfile");
                await Shell.Current.CurrentItem.Navigation.PushAsync(new NavigationPage(new MyProfilePage(_artGallery))); 
                //await Shell.Current.CurrentItem.CurrentItem.Navigation.PushAsync(new NavigationPage(new MyProfilePage(_artGallery)));
            }
            //Navigation.PushAsync(new MyProfilePage(_artGallery));
        }
        catch (Exception ex)
        {
            _ = DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void RegisterButton_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new RegistrationPage(_artGallery));
    }
}