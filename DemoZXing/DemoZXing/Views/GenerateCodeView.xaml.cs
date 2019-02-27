using DemoZXing.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoZXing.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenerateCodeView : ContentPage
	{
        public GenerateCodeView()
        {
            InitializeComponent();
            BindingContext = new GenerateCodeViewModel();
        }
    }
}