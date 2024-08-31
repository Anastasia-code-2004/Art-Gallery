using ArtGallerySystem.Application;
using ArtGallerySystem.Persistense;
using ArtGallerySystem.Persistense.Data;
using Camera.MAUI;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using ZXing.Net.Maui.Controls;

namespace ArtGallerySystem.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "ArtGallerySystem.UI.appsettings.json";

            var builder = MauiApp.CreateBuilder();
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCameraView()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FontAwesome6-Brands.otf", "FA6Brands");
                    fonts.AddFont("FontAwesome6-Regular.otf", "FA6Regular");
                });

#if DEBUG
            var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
            connStr = String.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<ApplicationDbContext>() 
                .UseSqlite(connStr)
                .Options;
            builder.Logging.AddDebug();
            builder.Services.AddApplication()
                            .AddPersistence(options)
                            .AddPersistence()
                            .RegisterPages()
                            .RegisterViewModels();
            
           DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait(); 
            
#endif

            return builder.Build();
        }
    }
}
