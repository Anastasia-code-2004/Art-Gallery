using System.Collections.ObjectModel;
using ArtGallerySystem.Application.ClientUseCases.Commands;
using ArtGallerySystem.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

public partial class ClientsViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public ClientsViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Client> Clients { get; set; } = [];
    
    [RelayCommand]
    async Task UpdateClientsAsync() => await GetClientsAsync();
    
    [RelayCommand]
    async Task GetTicketsForClientAsync(Client client) => await GotoTicketsForClientPage(client);
    private async Task GetClientsAsync()
    {
        var clients = await _mediator.Send(new GetClientsByRequest());
        await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Clients.Clear();
                foreach (var client in clients)
                {
                    Clients.Add(client);
                }
            }
        );
    }
    private async Task GotoTicketsForClientPage(Client client)
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "ClientId", client.Id}
        };
        await Shell.Current.GoToAsync(nameof(TicketsForClientPage), parameters);
    }
}