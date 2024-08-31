using System.Diagnostics;
using ArtGallerySystem.Application.PaintingUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Platform;

namespace ArtGallerySystem.UI.ViewModels;

public partial class AddPaintingViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    private byte[] _photoData;
    public AddPaintingViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private string _author;
    [ObservableProperty]
    private string _description;
    [ObservableProperty]
    private string _yearOfCreation;
    [ObservableProperty]
    private ImageSource _selectedPhoto = ImageSource.FromFile("painting.png");
    
    [RelayCommand]
    async Task AddPaintingAsync() => await AddPaintingHandleAsync();
    [RelayCommand]
    async Task ChoosePhotoAsync() => await ChoosePhotoHandleAsync();
    private async Task AddPaintingHandleAsync()
    {
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Author) || string.IsNullOrWhiteSpace(Description)
            || string.IsNullOrWhiteSpace(YearOfCreation))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }
        if (!int.TryParse(YearOfCreation, out _))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid year of creation", "OK");
            return;
        }
        if (int.Parse(YearOfCreation) < 0 || int.Parse(YearOfCreation) > DateTime.Now.Year)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid year of creation", "OK");
            return;
        }
        if (_photoData == null)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please select a photo", "OK");
            return;
        }
        var painting = await _mediator.Send(new AddPaintingCommand(Name, Author, Description, int.Parse(YearOfCreation), _photoData));

        var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Images");

        var fileName = $"{painting.Id}.png";
        var filePath_new = Path.Combine(folderPath, fileName);


        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
        var filePath = Path.Combine(folderPath, $"{painting.Id}.png");

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        await File.WriteAllBytesAsync(filePath, _photoData);


        await Shell.Current.GoToAsync("..");

    }
    private async Task ChoosePhotoHandleAsync()
    {
        var result = await MediaPicker.PickPhotoAsync();
        if (result != null)
        {
            await using (var stream = await result.OpenReadAsync())
            {
                _photoData = new byte[stream.Length];
                await stream.ReadAsync(_photoData, 0, _photoData.Length);
            }
            SelectedPhoto = ImageSource.FromStream(() => new MemoryStream(_photoData));
        }
    }
}