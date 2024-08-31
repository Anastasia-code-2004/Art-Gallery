using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class BuyMembershipPage : ContentPage
{
    public BuyMembershipPage(BuyMembershipViewModel buyMembershipViewModel)
    {
        InitializeComponent();
        BindingContext = buyMembershipViewModel;
    }
}