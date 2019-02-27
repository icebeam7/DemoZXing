using DemoZXing.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoZXing.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScannerView : ContentPage
	{
        public ScannerView()
        {
            InitializeComponent();
            BindingContext = new ScannerViewModel(this.Navigation);
        }
    }
}