using DemoIMC.Models;
using DemoIMC.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoIMC.ViewModels
{
    public class ImcsViewModel : BaseViewModel
    {
        #region Attributes
        public Imcs _imc;
        private int usuarioid;
        private string nombreuser;
        private string apellidouser;
        private string nombrecompletouser;
        private string sexouser;
        private int edaduser;
        private double pesouser;
        private double estaturauser;
        private double imc;
        private DateTime fecharegistro;
        private Usuarios userselected;
        //private bool _isRefreshing = false;
        #endregion

        #region Properties
        public int UsuarioID
        {
            get { return usuarioid; }
            set { SetValue(ref usuarioid, value); }
        }

        public string NombreUser
        {
            get { return nombreuser; }
            set { SetValue(ref nombreuser, value);
                OnPropertyChanged(nameof(NombreCompletoUser));
            }
        }

        public string ApellidoUser
        {
            get { return apellidouser; }
            set { SetValue(ref apellidouser, value);
                OnPropertyChanged(nameof(NombreCompletoUser));
            }
        }

        public string NombreCompletoUser
        {
            get { return $"{NombreUser} {ApellidoUser}"; }
            set { SetValue(ref nombrecompletouser, value); }
        }

        public string SexoUser
        {
            get { return sexouser; }
            set { SetValue(ref sexouser, value); }
        }

        public int EdadUser
        {
            get { return edaduser; }
            set { SetValue(ref edaduser, value); }
        }

        public double PesoUser
        {
            get { return pesouser; }
            set { SetValue(ref pesouser, value); }
        }

        public double EstaturaUser
        {
            get { return estaturauser; }
            set { SetValue(ref estaturauser, value); }
        }

        public double Imc
        {
            get { return imc; }
            set { SetValue(ref imc, value); }
        }

        public DateTime FechaRegistro
        {
            get { return fecharegistro; }
            set { SetValue(ref fecharegistro, value); }
        }

        public Usuarios UserSeleted
        {
            get { return userselected; }
            set { SetValue(ref userselected, value); }
        }

        public List<Imcs> ListImcs { get; set; } = new List<Imcs>();

        
        //public bool IsRefreshing
        //{
        //    get { return _isRefreshing; }
        //    set
        //    {
        //        _isRefreshing = value;
        //        OnPropertyChanged(nameof(IsRefreshing));
        //    }
        //}

        #endregion

        #region Constructors
        public ImcsViewModel(Imcs imc) : this()
        {
            this._imc = imc;
            if (imc != null)
            {
                UsuarioID = imc.UsuarioID;
                NombreUser = imc.NombreUser;
                ApellidoUser = imc.ApellidoUser;
                SexoUser = imc.SexoUser;
                EdadUser = imc.EdadUser;
                PesoUser = imc.PesoUser;
                EstaturaUser = imc.EstaturaUser;
                Imc = imc.Imc;
                FechaRegistro = imc.FechaRegistro;
            }
        }

        public ImcsViewModel()
        {
            GetImcs();
            InsertCommand = new Command(Insert);
            CalcularCommand = new Command(Calcular);
            DeleteCommand = new Command(Delete);
            CancelarCommand = new Command(Cancelar);
        }
        #endregion

        #region Methods
        private async void Calcular(object obj)
        {
            
            double calcuImc = UserSeleted.Peso / (UserSeleted.Estatura * UserSeleted.Estatura);
            await App.Current.MainPage.DisplayAlert("Resultado Obtenido", "Su IMC es: " + calcuImc + "\nUbicar en la tabla segun su calculo la Referencia e Implicaciones...", "Aceptar");
        }

        private async void Insert(object obj)
        {
            //CalculoImc();
            double calcuImc = UserSeleted.Peso / (Math.Pow(UserSeleted.Estatura, 2));
            var Servi = new Services<Imcs>();
            var imc = new Imcs();
            imc.UsuarioID = UsuarioID;
            imc.NombreUser = UserSeleted.Nombre;
            imc.ApellidoUser = UserSeleted.Apellido;
            imc.SexoUser = UserSeleted.Sexo;
            imc.EdadUser = UserSeleted.Edad;
            imc.PesoUser = UserSeleted.Peso;
            imc.EstaturaUser = UserSeleted.Estatura;
            imc.Imc = calcuImc;
            imc.FechaRegistro = DateTime.Now;
            var result = await Servi.Insert(imc);
            if (result == 1)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de Aviso", "Su IMC es: " + calcuImc, "Aceptar");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de Aviso", $"Error al guardar", "Aceptar");
            }
        }

        private async void Delete(object obj)
        {
            var Servi = new Services<Imcs>();
            var result = await Servi.Delete(_imc);
            if (result == 1)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de aviso", "Registro Eliminado con exito!!!", "Aceptar");
                await App.Current.MainPage.Navigation.PopAsync();

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de aviso", "Error al Eliminar", "Acepatr");
            }
        }

        private async void Cancelar(object obj)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
               
        public async void GetImcs()
        {
            var Servi = new Services<Imcs>();
            ListImcs = await Servi.GetAll();
        }

        #endregion

        #region Commands
        public Command CalcularCommand { get; set; }
        public Command InsertCommand { get; set; }
        public Command CancelarCommand { get; set; }
        public Command DeleteCommand { get; set; }
        //public ICommand RefreshCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //       {
        //           IsRefreshing = true;
        //           GetImcs();
        //           IsRefreshing = false;
        //       });
        //    }
        //}
        #endregion
    }
}

