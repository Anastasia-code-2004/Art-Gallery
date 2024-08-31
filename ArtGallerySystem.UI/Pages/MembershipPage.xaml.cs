using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages;

public partial class MembershipPage : ContentPage
{
    MembershipViewModel membershipViewModel;
    public MembershipPage(MembershipViewModel membershipViewModel)
    {
        InitializeComponent();
        BindingContext = membershipViewModel;
        this.membershipViewModel = membershipViewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        membershipViewModel.GetCategoryMembershipsAsync();
    }
}   