using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class AddMembershipCategoryPage : ContentPage
{
    public AddMembershipCategoryPage(AddMembershipCategoryViewModel addMembershipCategoryViewModel) 
    {
        InitializeComponent();
        BindingContext = addMembershipCategoryViewModel;
    }
}