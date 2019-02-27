using System.Windows.Input;
using System.Threading.Tasks;

using DemoZXing.Views;

using Xamarin.Forms;

namespace DemoZXing.ViewModels
{
    public class MenuViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand DefaultScannerCommand { get; set; }
        public ICommand CustomOverlayScannerCommand { get; set; }
        public ICommand ContinuousScannerCommand { get; set; }
        public ICommand CustomScannerPageCommand { get; set; }
        public ICommand GenerateCodeCommand { get; set; }

        public MenuViewModel(INavigation navigation)
        {
            Navigation = navigation;

            DefaultScannerCommand = new Command(async () => await GoToScannerView());
            CustomOverlayScannerCommand = new Command(async () => await GoToCustomOverlayView());
            ContinuousScannerCommand = new Command(async () => await GoToContinuousScanView());
            CustomScannerPageCommand = new Command(async () => await GoToCustomPageView());
            GenerateCodeCommand = new Command(async () => await GoToGenerateCodeView());
        }

        private async Task GoToScannerView() => await Navigation.PushAsync(new ScannerView());
        private async Task GoToCustomOverlayView() => await Navigation.PushAsync(new CustomOverlayView());
        private async Task GoToContinuousScanView() => await Navigation.PushAsync(new ContinuousScannerView());
        private async Task GoToCustomPageView() => await Navigation.PushAsync(new CustomPageView());
        private async Task GoToGenerateCodeView() => await Navigation.PushAsync(new GenerateCodeView());
    }
}
