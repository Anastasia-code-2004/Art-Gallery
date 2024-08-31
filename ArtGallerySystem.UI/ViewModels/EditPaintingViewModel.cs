using ArtGallerySystem.Application.PaintingUseCases.Commands;
using ArtGallerySystem.UI.Pages.Admin;
using ArtGallerySystem.UI.ValueConverters;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(PaintingId), "PaintingId")]
public partial class EditPaintingViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public int PaintingId { get; set; }

    [ObservableProperty]
    Painting _painting;
    [ObservableProperty]
    private ImageSource _selectedPhoto;
    
    private byte[] _photoData;
    
    public EditPaintingViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    [RelayCommand]
    void UpdateInfo() => GetInfo();
    
    [RelayCommand]
    async Task ChoosePhotoAsync() => await ChoosePhotoHandleAsync();
    
    [RelayCommand]
    async Task EditPaintingAsync() => await EditPaintingHandleAsync();
    private async void GetInfo()
    {
        Painting = await _mediator.Send(new GetPaintingByIdRequest(PaintingId));
        if (Painting.Photo != null)
        {
            SelectedPhoto = ImageSource.FromStream(() => new MemoryStream(Painting.Photo));
            _photoData = Painting.Photo;
        }
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
    private async Task EditPaintingHandleAsync()
    {
        if (string.IsNullOrWhiteSpace(Painting.Name) || string.IsNullOrWhiteSpace(Painting.Author) || string.IsNullOrWhiteSpace(Painting.Description)
            || Painting.YearOfCreation <= 0)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }
        if (_photoData != null)
        {
            Painting.Photo = _photoData;
        }
        var painting = await _mediator.Send(new EditPaintingCommand(Painting));

        var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Images");
        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
        var filePath = Path.Combine(folderPath, $"{painting.Id}.png");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        await File.WriteAllBytesAsync(filePath, _photoData);


        await Shell.Current.Navigation.PopAsync();
    }
        
}