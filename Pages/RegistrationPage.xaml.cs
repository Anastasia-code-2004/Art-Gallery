using ArtGalleryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryApp.Pages;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage(ArtGallery artGallery)
    {
        InitializeComponent();
        BindingContext = this;
        _email = _password = _phone = _name = _surname = string.Empty;
        _artGallery = artGallery;
    }

    private string _email;
    private string _phone;
    private string _name;
    private string _surname;
    private string _password;
    readonly ArtGallery _artGallery;
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
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
    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }
    private async void RegisterButton_OnClicked(object? sender, EventArgs e)
    {
        if (Email == "admin" || Phone == "admin")
        {
            _artGallery.RegisterAdmin(Password, Name, Surname, Email, Phone);   
        }
        else
        {
            _artGallery.RegisterClient(Password, Name, Surname, Email, Phone);
        }
       
        await Shell.Current.GoToAsync("//LogIn");
    }
}