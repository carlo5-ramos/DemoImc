using DemoIMC.Respaldo;
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
            ExportarCommand = new Command(() => ExportarBD());
            ImportarCommand = new Command(() => IMportarBD());

        }

        #region Metodos


        public async void ExportarBD()
        {
            var exportar = new Backup();
            

            var mensaje = await App.Current.MainPage.DisplayAlert("Indicaciones ", "La base de datos estara en la carpeta download", "Aceptar", "Cancel");

            if (mensaje == true)
            {
                exportar.BackupDatabase(); 
            }
            else
            {
                return;
            }
            
        }

        public async void IMportarBD()
        {
            var importar = new Backup();


            var mensaje = await App.Current.MainPage.DisplayAlert("Indicaciones ", "La base de datos Tiene que estar en la carpeta IMCAPP dentro de la carpeta DOwnload", "Aceptar", "Cancel");

            if (mensaje == true)
            {
                importar.Traer();
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
