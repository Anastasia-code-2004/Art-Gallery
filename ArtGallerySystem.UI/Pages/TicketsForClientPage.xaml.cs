using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class TicketsForClientPage : ContentPage
{
    TicketsForClientViewModel ticketsForClientViewModel;
    public TicketsForClientPage(TicketsForClientViewModel ticketsForClientViewModel)
    {
        InitializeComponent();
        this.ticketsForClientViewModel = ticketsForClientViewModel;
        BindingContext = ticketsForClientViewModel;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await ticketsForClientViewModel.GetTicketsAsync();
        //await Task.Run(async () => await collectionViewModel.GetPaintingsAsync());
        OnPropertyChanged(nameof(ticketsForClientViewModel.Tickets));

    }
}