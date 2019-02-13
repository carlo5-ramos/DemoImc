using DemoIMC.Models;
using DemoIMC.Services;
using DemoIMC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoIMC.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            OnAppearing();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var Servi = new Services<Imcs>();
            Listado.ItemsSource = await Servi.GetAll();
        }

        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.CalculosImcPage()
            {
                BindingContext = new ImcsViewModel((Imcs)e.SelectedItem)
            });
        }
    }
}
