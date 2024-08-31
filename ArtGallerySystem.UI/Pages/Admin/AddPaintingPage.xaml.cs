using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class AddPaintingPage : ContentPage
{
    public AddPaintingPage(AddPaintingViewModel addPaintingViewModel)
    {
        InitializeComponent();
        BindingContext = addPaintingViewModel;
    }
}