using DemoIMC.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoIMC.ViewModels
{
    public class SettingViewModel
    {
        public SettingViewModel()
        {
            ExportarCommand = new Command(() => Mensaje());

        }

        #region Metodos


        public async void Mensaje()
        {
            var mensaje = await App.Current.MainPage.DisplayAlert("hola", "haz guardadi", "ok", "Cancel");

            if (mensaje == true)
            {
                await App.Current.MainPage.Navigation.PushAsync(new ListUserPage());
            }
            else
            {
                return;
            }
            
        }


        #endregion

        //await App.Current.MainPage.Navigation.PushAsync(new ListUserPage ());
        #region Commands
        public Command ExportarCommand { get; set; }
        public Command ImportarCommand { get; set; }
       
        #endregion

    }
}
