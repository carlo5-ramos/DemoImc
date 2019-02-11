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
        }
    }
}