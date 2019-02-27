using System;
using System.Windows.Input;
using System.Threading.Tasks;

using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

using Xamarin.Forms;

namespace DemoZXing.ViewModels
{
    public class ContinuousScannerViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand ScannerCommand { get; set; }

        public ContinuousScannerViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ScannerCommand = new Command(async () => await ScanCode());
        }

        async Task ScanCode()
        {
            var options = new MobileBarcodeScanningOptions { DelayBetweenContinuousScans = 10000 };

            var overlay = new ZXingDefaultOverlay
            {
                ShowFlashButton = false,
                TopText = "Coloca el código de barras frente al dispositivo",
                BottomText = "El escaneo es automático",
                Opacity = 0.75
            };
            overlay.BindingContext = overlay;

            var page = new ZXingScannerPage(options, overlay)
            {
                Title = "Demo ZXing",
                DefaultOverlayShowFlashButton = true,
            };

            await Navigation.PushAsync(page);

            page.OnScanResult += (result) =>
            {
                page.IsScanning = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    page.Title = $"{DateTime.Now.ToShortTimeString()} | Código: {result.Text} | Formato: {result.BarcodeFormat}";
                });
            };
        }
    }
}
