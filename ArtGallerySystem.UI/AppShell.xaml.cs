using ArtGallerySystem.UI.Pages;
using ArtGallerySystem.UI.Pages.Admin;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(AdminProfilePage), typeof(AdminProfilePage));
            Routing.RegisterRoute(nameof(ClientsPage), typeof(ClientsPage));
            Routing.RegisterRoute(nameof(EditCollectionPage), typeof(EditCollectionPage));
            Routing.RegisterRoute(nameof(AddPaintingPage), typeof(AddPaintingPage));
            Routing.RegisterRoute(nameof(EditPaintingPage), typeof(EditPaintingPage));
            Routing.RegisterRoute(nameof(DetailsPaintingPage), typeof(DetailsPaintingPage));
            Routing.RegisterRoute(nameof(EditExhibitionsPage), typeof(EditExhibitionsPage));
            Routing.RegisterRoute(nameof(AddExhibitionPage), typeof(AddExhibitionPage));
            Routing.RegisterRoute(nameof(DetailsExhibitionPage), typeof(DetailsExhibitionPage));
            Routing.RegisterRoute(nameof(BuyTicketPage), typeof(BuyTicketPage));
            Routing.RegisterRoute(nameof(TicketCategoriesPage), typeof(TicketCategoriesPage));
            Routing.RegisterRoute(nameof(AddCategoryPage), typeof(AddCategoryPage));
            Routing.RegisterRoute(nameof(AddBankCardPage), typeof(AddBankCardPage));
            Routing.RegisterRoute(nameof(BankCardPage), typeof(BankCardPage));
            Routing.RegisterRoute(nameof(BuyTicketPage), typeof(BuyTicketPage));
            Routing.RegisterRoute(nameof(ChooseCardPage), typeof(ChooseCardPage));
            Routing.RegisterRoute(nameof(TicketsForClientPage), typeof(TicketsForClientPage));
            Routing.RegisterRoute(nameof(EditExhibitionPage), typeof(EditExhibitionPage));
            Routing.RegisterRoute(nameof(EditMembershipsPage), typeof(EditMembershipsPage));
            Routing.RegisterRoute(nameof(AddMembershipCategoryPage), typeof(AddMembershipCategoryPage));
            //Routing.RegisterRoute(nameof(MembershipPage), typeof(MembershipPage));
            Routing.RegisterRoute(nameof(BuyMembershipPage), typeof(BuyMembershipPage));
            Routing.RegisterRoute(nameof(QrCodePage), typeof(QrCodePage));
            Routing.RegisterRoute(nameof(ScanningPage), typeof(ScanningPage));
        }
    }
}
