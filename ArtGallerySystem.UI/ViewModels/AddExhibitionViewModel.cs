using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.Application.ExhibitionUseCases.Commands;
using ArtGallerySystem.Application.PaintingUseCases.Commands;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ArtGallerySystem.UI.ViewModels
{
    public partial class AddExhibitionViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AddExhibitionViewModel(IMediator mediator)
        {
            _mediator = mediator;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }
        public ObservableCollection<Painting> Paintings { get; set; } = [];
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _description;
        [ObservableProperty]
        private DateTime _startDate;
        [ObservableProperty] 
        private DateTime _endDate;
        [ObservableProperty] 
        private string _price;
        [ObservableProperty]
        private bool _isInExhibition;
        
        [RelayCommand]
        async Task AddExhibitionAsync() => await AddExhibitionHandleAsync();
        [RelayCommand]
        async Task UpdatePaintingsAsync() => await UpdatePaintingsHandleAsync();
        private async Task AddExhibitionHandleAsync()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(Price))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please fill all fields", "OK");
                return;
            }
            if(StartDate > EndDate)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid dates", "OK");
                return;
            }
            if (Decimal.Parse(Price) <= 0 || Price.Split(',').Length > 1 && Price.Split(',')[1].Length > 2)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid price", "OK");
                return;
            }
            if (!Paintings.Any(p => p.IsInExhibition))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please select at least one painting", "OK");
                return;
            }
            
            var exhibition = await _mediator.Send(new AddExhibitionCommand(Name, Description, StartDate, EndDate, Decimal.Parse(Price)));
            foreach (var painting in Paintings)
            {
                if (painting.IsInExhibition)
                {
                    painting.SetExhibition(exhibition.Id);
                    await _mediator.Send(new UpdatePaintingCommand(painting));
                }
            }
            await Shell.Current.GoToAsync("..");
        }
        private async Task UpdatePaintingsHandleAsync()
        {
            var paintings = await _mediator.Send(new GetPaintingsByRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Paintings.Clear();
                    foreach (var painting in paintings)
                    {
                        if(painting.ExhibitionId == 0) Paintings.Add(painting);
                    }
                }
            );
        }
    }
}
