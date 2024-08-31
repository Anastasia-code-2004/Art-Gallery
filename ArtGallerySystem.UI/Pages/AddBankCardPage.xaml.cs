using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class AddBankCardPage : ContentPage
{
    public AddBankCardPage(AddBankCardViewModel addBankCardViewModel)
    {
        InitializeComponent();
        BindingContext = addBankCardViewModel;
    }
}