using System.Collections.ObjectModel;
using System.Diagnostics;
using ArtGalleryApp.Entities;

namespace ArtGalleryApp.Pages.ForAdmin;

[QueryProperty(nameof(Refresh), "refresh")]
public partial class AdminCollectionPage : ContentPage
{
    private readonly ArtGallery _artGallery;
    private ObservableCollection<Painting> Paintings { get; set; }
    
    public bool Refresh
    {
        set
        {
            if (!value) return;
            foreach (var painting in _artGallery.Paintings.Where(painting => !Paintings.Contains(painting)))
            {
                Paintings.Add(painting);
            }
            //PaintingsCollection.ItemsSource = Paintings;
            
        }
    }
    public AdminCollectionPage(ArtGallery artGallery)
    {
        InitializeComponent();
        Paintings = [];
        _artGallery = artGallery;
        _artGallery.Paintings.ForEach(painting => Paintings.Add(painting));
        PaintingsCollection.ItemsSource = Paintings;
    }
    
    private async void AddPaintingButton_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new AddPaintingPage(_artGallery));
        
    }
    private async void Painting_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Painting painting)
        {
            Debug.WriteLine("Selected Painting: " + painting.Name);
            await Shell.Current.Navigation.PushAsync(new InfoPaintingPage(painting));
        }
    }

    private void DeleteSwipeItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;

        if (menuItem?.CommandParameter is Painting painting)
        {
            Paintings.Remove(painting);
            _artGallery.DeletePainting(painting);
        }
    }
}