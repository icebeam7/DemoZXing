using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

using DemoZXing.Helpers;

using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

using Xamarin.Forms;

namespace DemoZXing.ViewModels
{
    public class CustomOverlayViewModel : BaseViewModel
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

        public CustomOverlayViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ScannerCommand = new Command(async () => await ScanCode());
            barcodeText = "N/A";
        }

        async Task ScanCode()
        {
            var grid = new Grid() { BackgroundColor = Color.Transparent };
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });

            var buttonCancel = new Button() { BackgroundColor = Color.Black, Text = "Cancelar" };
            Grid.SetRow(buttonCancel, 1);
            Grid.SetColumn(buttonCancel, 0);

            var buttonHelp = new Button() { BackgroundColor = Color.Black, Text = "Torch" };
            Grid.SetRow(buttonHelp, 1);
            Grid.SetColumn(buttonHelp, 1);

            grid.Children.Add(buttonCancel);
            grid.Children.Add(buttonHelp);

            var options = new MobileBarcodeScanningOptions();

            options.PossibleFormats = new List<BarcodeFormat>()
            {
                ZXing.BarcodeFormat.EAN_8,
                ZXing.BarcodeFormat.EAN_13,
                ZXing.BarcodeFormat.AZTEC,
                ZXing.BarcodeFormat.QR_CODE
            };

            var page = new ZXingScannerPage(options, grid)
            {
                Title = "Demo ZXing",
            };

            buttonCancel.Clicked += async delegate { 
                page.IsScanning = false;
                await Navigation.PopAsync();
            };

            buttonHelp.Clicked += async delegate {
                await page.DisplayAlert("Ayuda", "Coloca el código frente al dispositivo para escanearlo", "OK");
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
