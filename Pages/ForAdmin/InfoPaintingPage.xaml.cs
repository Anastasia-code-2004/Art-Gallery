using ArtGalleryApp.Entities;


namespace ArtGalleryApp.Pages.ForAdmin;

public partial class InfoPaintingPage : ContentPage
{
	Painting _painting;
    public InfoPaintingPage(Painting painting)
    {
        InitializeComponent();
        _painting = painting;
        BindingContext = this;
    }
    public Painting Painting
    {
        get => _painting;
        set
        {
            _painting = value;
            OnPropertyChanged(nameof(Painting));
        }
    }
}