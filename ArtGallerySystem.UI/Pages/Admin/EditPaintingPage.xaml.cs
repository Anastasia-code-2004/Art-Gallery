using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class EditPaintingPage : ContentPage
{
    public EditPaintingPage(EditPaintingViewModel editPaintingViewModel)
    {
        InitializeComponent();
        BindingContext = editPaintingViewModel;
    }
}