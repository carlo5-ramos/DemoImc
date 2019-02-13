using DemoIMC.Models;
using DemoIMC.Services;
using DemoIMC.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoIMC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListUserPage : ContentPage
	{
		public ListUserPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            OnAppearing();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var Servi = new Services<Usuarios>();
            UserListView.ItemsSource = await Servi.GetAll();
        }

        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.UserPage()
            {
                BindingContext = new UserViewModel((Usuarios)e.SelectedItem)
            });
        }
    }
}