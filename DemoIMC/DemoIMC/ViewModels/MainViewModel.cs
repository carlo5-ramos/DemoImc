//using DemoIMC.Backup;
using DemoIMC.Models;
using DemoIMC.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DemoIMC.ViewModels
{
    public class MainViewModel
    {
        #region Constructors
        public MainViewModel()
        {
            ViewUserCommand = new Command(async () =>
           {
               await App.Current.MainPage.Navigation.PushAsync(new ListUserPage());
           });

            ViewImcCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new ImcPage());
            });
            //RespaldoCommand = new Command(()=> Respaldo());
        }

        #region Methods
        //void Respaldo()
        //{
        //    var respaldo = new Respaldo();
        //    respaldo.BackupDatabase();
        //}
        #endregion
        #endregion

        #region Commands
        public Command ViewUserCommand { get; set; }
        public Command ViewImcCommand { get; set; }
        
        #endregion
    }
}
