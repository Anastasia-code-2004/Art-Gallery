using Microsoft.Extensions.Logging;
using ArtGalleryApp.Services;
using ArtGalleryApp.Entities;
using ArtGalleryApp.Pages;
using ArtGalleryApp.Pages.ForAdmin;
namespace ArtGalleryApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FontAwesome6-Brands.otf", "FA6Brands");
                fonts.AddFont("FontAwesome6-Regular.otf", "FA6Regular");
            });
        Routing.RegisterRoute("AdminCollection", typeof(AdminCollectionPage));
        Routing.RegisterRoute("AdminProfile", typeof(AdminProfilePage));
        Routing.RegisterRoute("Collection", typeof(CollectionPage));
        Routing.RegisterRoute("LogIn", typeof(LogInPage));
        Routing.RegisterRoute("MyProfile", typeof(MyProfilePage));


        builder.Services.AddScoped<IDbService, SQLiteService>();
        builder.Services.AddScoped<AccountsSystem>();
        builder.Services.AddScoped<ArtGallery>();
        builder.Services.AddScoped<LogInPage>();
        builder.Services.AddScoped<RegistrationPage>();
        builder.Services.AddScoped<MyProfilePage>();
        builder.Services.AddScoped<AdminProfilePage>();
        builder.Services.AddTransient<AdminCollectionPage>();
        builder.Services.AddScoped<ClientsPage>();
        builder.Services.AddScoped<AddPaintingPage>();
        builder.Services.AddScoped<InfoPaintingPage>();
        builder.Services.AddScoped<CollectionPage>();
        builder.Services.AddScoped<AdminsPage>();
        builder.Services.AddScoped<ClientsPage>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}