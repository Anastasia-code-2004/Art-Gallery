using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class LogInPage : ContentPage
{
    public LogInPage(LogInViewModel logInViewModel)
    {
        InitializeComponent();
        BindingContext = logInViewModel;
    }
}