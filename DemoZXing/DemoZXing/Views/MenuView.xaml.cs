using DemoZXing.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoZXing.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView : ContentPage
	{
        public MenuView()
        {
            InitializeComponent();
            BindingContext = new MenuViewModel(this.Navigation);
        }
    }
}