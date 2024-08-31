using ArtGallerySystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class EditExhibitionsPage : ContentPage
{
    EditExhibitionsViewModel editExhibitionsViewModel;
    public EditExhibitionsPage(EditExhibitionsViewModel editExhibitionsViewModel)
    {
        InitializeComponent();
        BindingContext = editExhibitionsViewModel;
        this.editExhibitionsViewModel = editExhibitionsViewModel;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await editExhibitionsViewModel.GetExhibitionsAsync();
        OnPropertyChanged(nameof(editExhibitionsViewModel.Exhibitions));
    }
}
