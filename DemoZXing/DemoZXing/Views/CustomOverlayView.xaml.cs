using DemoZXing.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoZXing.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomOverlayView : ContentPage
	{
        public CustomOverlayView()
        {
            InitializeComponent();
            BindingContext = new CustomOverlayViewModel(this.Navigation);
        }
    }
}