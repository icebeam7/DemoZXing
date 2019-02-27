using DemoZXing.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoZXing.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContinuousScannerView : ContentPage
	{
        public ContinuousScannerView()
        {
            InitializeComponent();
            BindingContext = new ContinuousScannerViewModel(this.Navigation);
        }
    }
}