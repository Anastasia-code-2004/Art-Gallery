using ArtGallerySystem.UI.Pages;
using ArtGallerySystem.UI.Pages.Admin;
using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI;

public static class DependencyInjection
{
    public static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services.AddTransient<MainPage>()
            .AddTransient<LogInPage>()
            .AddTransient<ProfilePage>()
            .AddTransient<ExhibitionsPage>()
            .AddTransient<CollectionPage>()
            .AddTransient<AboutPage>()
            .AddTransient<RegisterPage>()
            .AddTransient<AdminProfilePage>()
            .AddTransient<ClientsPage>()
            .AddTransient<EditCollectionPage>()
            .AddTransient<AddPaintingPage>()
            .AddTransient<EditPaintingPage>()
            .AddTransient<CollectionPage>()
            .AddTransient<DetailsPaintingPage>()
            .AddTransient<EditExhibitionsPage>()
            .AddTransient<AddExhibitionPage>()
            .AddTransient<DetailsExhibitionPage>()
            .AddTransient<BuyTicketPage>()
            .AddTransient<TicketCategoriesPage>()
            .AddTransient<AddCategoryPage>()
            .AddTransient<AddBankCardPage>()
            .AddTransient<BankCardPage>()
            .AddTransient<BuyTicketPage>()
            .AddTransient<ChooseCardPage>()
            .AddTransient<TicketsForClientPage>()
            .AddTransient<EditExhibitionPage>()
            .AddTransient<EditMembershipsPage>()
            .AddTransient<AddMembershipCategoryPage>()
            .AddTransient<MembershipPage>()
            .AddTransient<BuyMembershipPage>()
            .AddTransient<QrCodePage>()
            .AddTransient<ScanningPage>();
        return services;
    }
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<LogInViewModel>()
            .AddTransient<MainViewModel>()
            .AddTransient<ProfileViewModel>()
            .AddTransient<RegisterViewModel>()
            .AddTransient<AdminProfileViewModel>()
            .AddTransient<ClientsViewModel>()
            .AddTransient<EditCollectionViewModel>()
            .AddTransient<AddPaintingViewModel>()
            .AddTransient<EditPaintingViewModel>()
            .AddTransient<CollectionViewModel>()
            .AddTransient<DetailsPaintingViewModel>()
            .AddTransient<EditExhibitionsViewModel>()
            .AddTransient<AddExhibitionViewModel>()
            .AddTransient<ExhibitionsViewModel>()
            .AddTransient<DetailsExhibitionViewModel>()
            .AddTransient<BuyTicketViewModel>()
            .AddTransient<EditCategoriesViewModel>()
            .AddTransient<AddCategoryViewModel>()
            .AddTransient<AddBankCardViewModel>()
            .AddTransient<BankCardViewModel>()
            .AddTransient<BuyTicketViewModel>()
            .AddTransient<ChooseCardViewModel>()
            .AddTransient<TicketsForClientViewModel>()
            .AddTransient<EditExhibitionViewModel>()
            .AddTransient<EditMembershipsViewModel>()
            .AddTransient<AddMembershipCategoryViewModel>()
            .AddTransient<MembershipViewModel>()
            .AddTransient<BuyMembershipViewModel>()
            .AddTransient<QrCodeViewModel>()
            .AddTransient<ScanningViewModel>();
        return services;
    }
}