using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class AddCategoryPage : ContentPage
{
    public AddCategoryPage(AddCategoryViewModel addCategoryViewModel)
    {
        InitializeComponent();
        BindingContext = addCategoryViewModel;
    }
}