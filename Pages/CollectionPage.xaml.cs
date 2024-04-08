using ArtGalleryApp.Entities;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ArtGalleryApp.Pages.ForAdmin;

namespace ArtGalleryApp.Pages;

public partial class CollectionPage : ContentPage
{
    private readonly ArtGallery _artGallery;
    private ObservableCollection<Painting> Paintings { get; set; }
    public CollectionPage(ArtGallery artGallery)
    {
        InitializeComponent();
        Paintings = [];
        _artGallery = artGallery;
        _artGallery.Paintings.ForEach(painting => Paintings.Add(painting));
        PaintingsCollection.ItemsSource = Paintings;
        _artGallery.PaintingsChanged += UpdatePaintings;
        //BindingContext = Paintings;
    }

    private void UpdatePaintings(object? sender, EventArgs e)
    {
        Paintings = [];
        _artGallery.Paintings.ForEach(painting => Paintings.Add(painting));
        PaintingsCollection.ItemsSource = Paintings;
    }

    private async void Painting_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Painting painting)
        {
            Debug.WriteLine("Selected Painting: " + painting.Name);
            await Shell.Current.Navigation.PushAsync(new InfoPaintingPage(painting));
        }
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    Paintings = [];

    //    _artGallery.Paintings.ForEach(painting => Paintings.Add(painting));
    //    PaintingsCollection.ItemsSource = Paintings;
    //}
}