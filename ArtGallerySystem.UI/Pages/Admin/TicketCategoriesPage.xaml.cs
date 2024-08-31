using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class TicketCategoriesPage : ContentPage
{
    EditCategoriesViewModel editCategoriesViewModel;
    public TicketCategoriesPage(EditCategoriesViewModel editCategoriesViewModel)
    {
        InitializeComponent();
        BindingContext = editCategoriesViewModel;
        this.editCategoriesViewModel = editCategoriesViewModel;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await editCategoriesViewModel.GetCategoriesAsync();
    }
}