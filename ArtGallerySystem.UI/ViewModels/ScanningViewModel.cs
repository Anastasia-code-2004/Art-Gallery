using ArtGallerySystem.Application.QrCodeUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ArtGallerySystem.UI.ViewModels
{
    public partial class ScanningViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private bool _isAlertDisplayed;
        private bool _isProcessing = false;

        public ScanningViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [RelayCommand]
        public async Task ProcessScannedBarcodes(string value)
        {
            if (_isProcessing) return;  
            _isProcessing = true;
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    await ShowAlert("Error", "QR code is empty.", "OK");
                    _isProcessing = false;
                    return;
                }

                Regex regex = new(@"\d+");
                MatchCollection matches = regex.Matches(value);

                if (matches.Count != 3)
                {
                    await ShowAlert("Error", "Invalid QR code format.", "OK");
                    _isProcessing = false;
                    return;
                }

                var qrCode = await _mediator.Send(new GetQrCodeByGeneralInfo(int.Parse(matches[0].Value), int.Parse(matches[1].Value), int.Parse(matches[2].Value)));

                if (qrCode == null)
                {
                    await ShowAlert("Error", "Invalid QR code.", "OK");
                    _isProcessing = false;
                    return;
                }

                if (qrCode.IsUsed)
                {
                    await ShowAlert("Error", "QrCode has already been used.", "OK");
                    _isProcessing = false;
                    return;
                }

                qrCode.IsUsed = true;
                await _mediator.Send(new UpdateQrCodeCommand(qrCode));

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Shell.Current.Navigation.PopAsync();
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error processing QR code: {ex.Message}");
                await ShowAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
            finally
            {
                _isProcessing = false;  
            }
        }

        private async Task ShowAlert(string title, string message, string cancel)
        {
            if (_isAlertDisplayed) return;

            _isAlertDisplayed = true;
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await App.Current.MainPage.DisplayAlert(title, message, cancel);
                _isAlertDisplayed = false;
            });
        }
    }
}
