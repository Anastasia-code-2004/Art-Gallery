using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class ChooseCardPage : ContentPage
{
    ChooseCardViewModel chooseCardViewModel;
    public ChooseCardPage(ChooseCardViewModel chooseCardViewModel)
    {
        InitializeComponent();
        BindingContext = chooseCardViewModel;
        this.chooseCardViewModel = chooseCardViewModel;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await chooseCardViewModel.UpdateBankCardsHandleAsync();
        OnPropertyChanged(nameof(chooseCardViewModel.BankCards));
    }
}