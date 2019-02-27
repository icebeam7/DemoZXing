using System.Windows.Input;
using System.Threading.Tasks;

using DemoZXing.Helpers;

using ZXing;
using ZXing.Net.Mobile.Forms;

using Xamarin.Forms;

namespace DemoZXing.ViewModels
{
    public class ScannerViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand ScannerCommand { get; set; }

        private string barcodeText;

        public string BarcodeText
        {
            get => barcodeText;
            set { barcodeText = value; OnPropertyChanged(); }
        }

        private BarcodeFormat _barcodeFormat;

        public string BarcodeFormat
        {
            get => BarcodeFormatConverter.ConvertEnumToString(_barcodeFormat);
            set
            {
                _barcodeFormat = (value != null)
                    ? BarcodeFormatConverter.ConvertStringToEnum(value)
                    : ZXing.BarcodeFormat.QR_CODE;
                OnPropertyChanged();
            }
        }

        public ScannerViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ScannerCommand = new Command(async () => await ScanCode());
            barcodeText = "N/A";
        }

        async Task ScanCode()
        {
            var overlay = new ZXingDefaultOverlay
            {
                ShowFlashButton = false,
                TopText = "Coloca el código de barras frente al dispositivo",
                BottomText = "El escaneo es automático",
                Opacity = 0.75
            };
            overlay.BindingContext = overlay;

            var page = new ZXingScannerPage(null, overlay)
            {
                Title = "Demo ZXing",
                DefaultOverlayShowFlashButton = true,
            };
            await Navigation.PushAsync(page);

            page.OnScanResult += (result) =>
            {
                page.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    BarcodeText = result.Text;
                    BarcodeFormat = BarcodeFormatConverter.ConvertEnumToString(result.BarcodeFormat);
                });
            };
        }
    }
}