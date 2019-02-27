using DemoZXing.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoZXing.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomPageView : ContentPage
	{
        public CustomPageView()
        {
            InitializeComponent();
            BindingContext = new CustomPageViewModel(this.Navigation);
        }
    }
}