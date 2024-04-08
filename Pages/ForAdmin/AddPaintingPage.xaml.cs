using ArtGalleryApp.Entities;

namespace ArtGalleryApp.Pages.ForAdmin;

public partial class AddPaintingPage : ContentPage
{
	private readonly ArtGallery _artGallery;
	
	public AddPaintingPage(ArtGallery artGallery)
	{
		InitializeComponent();
		_artGallery = artGallery;
		BindingContext = this;
	}
    string _name;
    string _author;
    int _yearofcreation;
    string _imagepath;
    public string Name
	{
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public string Author
    {
        get => _author;
        set
        {
            _author = value;
            OnPropertyChanged(nameof(Author));
        }
    }
    public int YearofCreation
    {
        get => _yearofcreation;
        set
        {
            _yearofcreation = value;
            OnPropertyChanged(nameof(YearofCreation));
        }
    }
    public string ImagePath
    {
        get => _imagepath;
        set
        {
            _imagepath = value;
            OnPropertyChanged(nameof(ImagePath));
        }
    }
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        Painting painting = new()
        {
            Name = Name,
            Author = Author,
            YearOfCreation = YearofCreation,
            ImagePath = ImagePath
        };
        const bool refresh = true;
        _artGallery.AddPainting(painting);
        await Shell.Current.GoToAsync($"//AdminCollection?refresh={refresh}");
        //await Navigation.PushAsync(new NavigationPage(new AdminCollectionPage(_artGallery)));

    }
}