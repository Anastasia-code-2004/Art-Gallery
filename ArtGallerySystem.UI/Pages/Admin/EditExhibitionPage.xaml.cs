using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class EditExhibitionPage : ContentPage
{
    public EditExhibitionPage(EditExhibitionViewModel editExhibitionViewModel)
    {
        InitializeComponent();
        BindingContext = editExhibitionViewModel;
    }
}