using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class EditCollectionPage : ContentPage
{
    readonly EditCollectionViewModel editCollectionViewModel;
    public EditCollectionPage(EditCollectionViewModel editCollectionViewModel)
    {
        InitializeComponent();
        BindingContext = editCollectionViewModel;
        this.editCollectionViewModel = editCollectionViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await editCollectionViewModel.GetPaintingsAsync();
        OnPropertyChanged(nameof(editCollectionViewModel.Paintings));

    }
}