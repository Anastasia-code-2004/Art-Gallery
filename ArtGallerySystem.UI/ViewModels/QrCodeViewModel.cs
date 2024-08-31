using ArtGallerySystem.Application.ExhibitionUseCases.Commands;
using ArtGallerySystem.Application.MembershipUseCases.Commands;
using ArtGallerySystem.Application.QrCodeUseCases.Commands;
using ArtGallerySystem.Domain.Entities;
using ArtGallerySystem.Domain.Services;
using ArtGallerySystem.UI.Helpers;
using ArtGallerySystem.UI.ValueConverters;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.UI.ViewModels
{
    public partial class QrCodeViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public ObservableCollection<QrCodeWithExhibition> QrCodes { get; set; } = [];


        public QrCodeViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [RelayCommand]
        async Task UpdateQrCodes() => await GetQrCodesAsync();
        private async Task GetQrCodesAsync()
        {
            var membership = await _mediator.Send(new GetMembershipByClientIdRequest(UserService.GetCurrentUser().Id));
            if (membership == null)
            {
                return;
            }
            var qrcodes = await _mediator.Send(new GetQrCodeByClientIdRequest(UserService.GetCurrentUser().Id));
            var exhibitions = await _mediator.Send(new GetExhibitionsByRequest());
            var existingExhibitionIds = qrcodes.Select(q => q.ExhibitionId).ToHashSet();
            var exhibitionsWithoutQrCodes = exhibitions
                                            .Where(e => e.EndDate >= DateTime.Now && !existingExhibitionIds.Contains(e.Id))
                                            .ToList();
            foreach (var exhibition in exhibitionsWithoutQrCodes)
            {
                await _mediator.Send(new AddQrCodeCommand(exhibition.Id, UserService.GetCurrentUser().Id, membership.Id));
            }

            qrcodes = await _mediator.Send(new GetQrCodeByClientIdRequest(UserService.GetCurrentUser().Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                QrCodes.Clear();
                foreach (var qrcode in qrcodes)
                {
                    if (qrcode.Exhibition.EndDate < DateTime.Now)
                    {
                        continue;
                    }
                    QRCodeGenerator qrGenerator = new();
                    
                    string result = $"{qrcode.ClientId}, {qrcode.ExhibitionId}, {qrcode.MembershipId}";
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(result, QRCodeGenerator.ECCLevel.L);

                    PngByteQRCode qRCode = new(qrCodeData);
                    byte[] qrCodeBytes = qRCode.GetGraphic(20);
                    ImageSource qrImageSource = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
                    QrCodes.Add(new QrCodeWithExhibition
                    {
                        QrCode = qrImageSource,
                        ExhibitionName = qrcode.Exhibition.Name,
                        IsUsed = qrcode.IsUsed 
                    });
                    
                }
            });
            
        }
    }
}


