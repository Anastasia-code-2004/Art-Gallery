using System.Collections.ObjectModel;
using ArtGallerySystem.Application.CategoryUseCases.Commands;
using ArtGallerySystem.UI.Pages.Admin;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

public partial class EditCategoriesViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    [ObservableProperty]
    Category _selectedCategory;

    public EditCategoriesViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Category> Categories { get; set; } = [];
    [RelayCommand]
    async Task UpdateCategoriesAsync() => await GetCategoriesAsync();
    [RelayCommand]
    async Task AddCategoryAsync() => await GotoAddCategoryPageAsync();
    [RelayCommand]
    async Task DeleteCategoryAsync(int categId) => await DeleteCategoryHandleAsync(categId);
    public async Task GetCategoriesAsync()
    {
        var categories = await _mediator.Send(new GetCategoriesByRequest());
        await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Categories.Clear();
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
        );
    }
    private async Task GotoAddCategoryPageAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddCategoryPage));
    }
    private async Task DeleteCategoryHandleAsync(int categId)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand(categId));
        if (result)
        {
            await GetCategoriesAsync();
        }
    }
}
