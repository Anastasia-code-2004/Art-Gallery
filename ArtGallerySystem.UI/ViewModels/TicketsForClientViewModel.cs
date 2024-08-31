using System.Collections.ObjectModel;
using ArtGallerySystem.Application.MembershipUseCases.Commands;
using ArtGallerySystem.Application.TicketUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(ClientId), "ClientId")]
public partial class TicketsForClientViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public int ClientId { get; set; }

    public TicketsForClientViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Ticket> Tickets { get; set; } = [];

    [ObservableProperty]
    Membership _membership;

    [RelayCommand]
    async Task UpdateTicketsAsync() => await GetTicketsAsync();
    public async Task GetTicketsAsync()
    {
        var tickets = await _mediator.Send(new GetTicketsByClientIdRequest(ClientId));
        var membership = await _mediator.Send(new GetMembershipByClientIdRequest(ClientId));
       
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            if (membership != null)
            {
                Membership = membership;
            }
            Tickets.Clear();
            foreach (var ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        }
        );
    }
}