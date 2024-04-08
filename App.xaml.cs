using ArtGalleryApp.Entities;
namespace ArtGalleryApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        //DependencyService.Register<ArtGallery>();
    }
}