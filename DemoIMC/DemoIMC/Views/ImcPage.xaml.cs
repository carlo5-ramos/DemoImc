using DemoIMC.Models;
using DemoIMC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var Servi = new Services<Usuarios>();
            pkUsuario.ItemsSource = await Servi.GetAll();
            btnCalcular.Clicked += BtnCalcular_Clicked;
        }

        private async void BtnCalcular_Clicked(object sender, EventArgs e)
        {
            if (pkUsuario.ItemsSource.Equals(""))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe seleccionar un usuario para efectuar el calculo", "Aceptar");
                pkUsuario.Focus();
                return;
            }
        }
    }
}