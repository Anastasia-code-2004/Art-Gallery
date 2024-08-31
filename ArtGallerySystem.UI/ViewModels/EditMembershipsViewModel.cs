using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.Application.CategoryMembershipUseCases.Commands;
using ArtGallerySystem.UI.Pages.Admin;

namespace ArtGallerySystem.UI.ViewModels
{
    public partial class EditMembershipsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        
        [ObservableProperty]
        CategoryMembership _selectedMembershipCategory;

        public EditMembershipsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<CategoryMembership> MembershipCategories { get; set; } = [];
        [RelayCommand]
        async Task UpdateMembershipCategoriesAsync() => await GetMembershipCategoriesAsync();
        [RelayCommand]
        async Task AddMembershipCategoryAsync() => await GotoAddMembershipCategoryPageAsync();
        [RelayCommand]
        async Task DeleteMembershipCategoryAsync(int categId) => await DeleteMembershipCategoryHandleAsync(categId);
        public async Task GetMembershipCategoriesAsync()
        {
            var categories = await _mediator.Send(new GetCategoriesMembershipByRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    MembershipCategories.Clear();
                    foreach (var category in categories)
                    {
                        MembershipCategories.Add(category);
                    }
                }
            );
        }
        private async Task GotoAddMembershipCategoryPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddMembershipCategoryPage));
        }
        private async Task DeleteMembershipCategoryHandleAsync(int categId)
        {
            var result = await _mediator.Send(new DeleteCategoryMembershipCommand(categId));
            if (result)
            {
                await GetMembershipCategoriesAsync();
            }
        }

    }
}
