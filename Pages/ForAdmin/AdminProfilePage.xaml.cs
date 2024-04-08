using ArtGalleryApp.Entities;
using System.Diagnostics;
namespace ArtGalleryApp.Pages.ForAdmin;

public partial class AdminProfilePage : ContentPage
{
    private readonly ArtGallery _artGallery;
    private Admin _admin;
    public AdminProfilePage(ArtGallery artGallery)
    {
        InitializeComponent();
        _artGallery = artGallery;
        _admin = (Admin)_artGallery.GetCurrentUser();
        BindingContext = this;
    }

    public Admin Admin
    {
        get => _admin;
        set
        {
            _admin = value;
            OnPropertyChanged(nameof(Admin));
        }
    }
    private async void LogOutButton_OnClicked(object? sender, EventArgs e)
    {
        _artGallery.Logout(_admin.Email, _admin.Password);
        //await Shell.Current.Navigation.PopToRootAsync();
        Application.Current.MainPage = new AppShell();
        await Shell.Current.CurrentItem.Navigation.PushAsync(new NavigationPage(new LogInPage(_artGallery)));
        
        await Shell.Current.GoToAsync("//LogIn");
        //await Shell.Current.CurrentItem.CurrentItem.Navigation.PushAsync(new NavigationPage(new LogInPage(_artGallery)));

        //await Shell.Current.CurrentItem.CurrentItem.Navigation.PushAsync(new NavigationPage(new LogInPage(_artGallery)));
    }

    private async void AdminsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminsPage(_artGallery));
    }

    private async void ClientsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientsPage(_artGallery));
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Admin = (Admin)_artGallery.GetCurrentUser();
        //Name.Text = Admin.Name;
        //Surname.Text = Admin.Surname;
        Debug.WriteLine('\n');
        Debug.WriteLine("Admin: " + Admin.Password);
    }
}