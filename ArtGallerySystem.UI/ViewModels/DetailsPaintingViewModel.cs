using System.Globalization;
using ArtGallerySystem.UI.ValueConverters;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(Painting), "Painting")]
public partial class DetailsPaintingViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    [ObservableProperty]
    Painting _painting;
    
    [ObservableProperty]
    private ImageSource _selectedPhoto;
    
    public DetailsPaintingViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    [RelayCommand]
    void UpdateInfo() => GetInfo();
    private async void GetInfo()
    {
        BytesToImageSourceConverter converter = new();
        SelectedPhoto = converter.Convert(Painting.Photo, typeof(ImageSource), null, CultureInfo.CurrentCulture) as ImageSource;
    }
}