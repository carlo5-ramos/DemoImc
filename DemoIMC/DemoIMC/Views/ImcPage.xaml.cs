using DemoIMC.Models;
using DemoIMC.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoIMC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImcPage : ContentPage
	{
		public ImcPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var Servi = new Services<Usuarios>();
            pkUsuario.ItemsSource = await Servi.GetAll();
        }
    }
}