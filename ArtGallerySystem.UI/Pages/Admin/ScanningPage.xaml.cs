using ArtGallerySystem.UI.ViewModels;
using ZXing;

namespace ArtGallerySystem.UI.Pages.Admin;

public partial class ScanningPage : ContentPage
{
	public ScanningPage(ScanningViewModel scanningViewModel)
	{
		InitializeComponent();
		barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
		{
			Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
			AutoRotate = true,
			TryInverted = true,
			Multiple = true
		};
		BindingContext = scanningViewModel;
	}

    private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        var scanningViewModel = BindingContext as ScanningViewModel;
		var barcode = e.Results.FirstOrDefault();
		scanningViewModel?.ProcessScannedBarcodes(barcode.Value);
    }
}