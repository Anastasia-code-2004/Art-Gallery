using ArtGallerySystem.UI.ViewModels;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class EditMembershipsPage : ContentPage
{
	EditMembershipsViewModel editMembershipsViewModel;
	public EditMembershipsPage(EditMembershipsViewModel editMembershipsViewModel)
	{
		InitializeComponent();
		BindingContext = editMembershipsViewModel;
		this.editMembershipsViewModel = editMembershipsViewModel;
	}
	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await editMembershipsViewModel.GetMembershipCategoriesAsync();
		OnPropertyChanged(nameof(editMembershipsViewModel.MembershipCategories));
	}
}