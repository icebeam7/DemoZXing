using System.Windows.Input;
using System.Threading.Tasks;

using DemoZXing.Helpers;

using ZXing;

using Xamarin.Forms;

namespace DemoZXing.ViewModels
{
    public class CustomPageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand OnScanResultCommand { get; set; }

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

        public CustomPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            OnScanResultCommand = new Command(async () => await ScanResult());
            barcodeText = "N/A";
        }

        public Result Result { get; set; }

        private bool isAnalyzing = true;

        public bool IsAnalyzing
        {
            get => this.isAnalyzing;
            set
            {
                if (!bool.Equals(this.isAnalyzing, value))
                {
                    this.isAnalyzing = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private bool isScanning = true;

        public bool IsScanning
        {
            get => this.isScanning;
            set
            {
                if (!bool.Equals(this.isScanning, value))
                {
                    this.isScanning = value;
                    this.OnPropertyChanged();
                }
            }
        }

        async Task ScanResult()
        {
            IsAnalyzing = false;
            IsScanning = false;

            Device.BeginInvokeOnMainThread(async () =>
            {
                BarcodeText = Result.Text;
                BarcodeFormat = BarcodeFormatConverter.ConvertEnumToString(Result.BarcodeFormat);
            });
        }
    }
}