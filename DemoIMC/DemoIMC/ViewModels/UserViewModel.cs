using DemoIMC.Models;
using DemoIMC.Services;
using DemoIMC.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DemoIMC.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        #region Attributes
        public Usuarios _users;

        private string nombre;
        private string apellido;
        private string nombreCompleto;
        private string sexo;
        private int edad;
        private double peso;
        private double estatura;
        #endregion

        #region Properties
        public string Nombre
        {
            get { return nombre; }
            set { SetValue(ref nombre, value);
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }
        public string Apellido
        {
            get { return apellido; }
            set { SetValue(ref apellido, value);
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }
        
        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
            set { SetValue(ref nombreCompleto, value); }
        }
        public string Sexo
        {
            get { return sexo; }
            set { SetValue(ref sexo, value); }
        }
        public int Edad
        {
            get { return edad; }
            set { SetValue(ref edad, value); }
        }
        public double Peso
        {
            get { return peso; }
            set { SetValue(ref peso, value); }
        }
        public double Estatura
        {
            get { return estatura; }
            set { SetValue(ref estatura, value); }
        }

        public List<Usuarios> ListUsuarios { get; set; } = new List<Usuarios>();
        #endregion

        #region Constructors
        public UserViewModel(Usuarios user) : this()
        {
            this._users = user;
            if (user != null)
            {
                Nombre = user.Nombre;
                Apellido = user.Apellido;
                Sexo = user.Sexo;
                Edad = user.Edad;
                Peso = user.Peso;
                Estatura = user.Estatura;
            }
        }

        public UserViewModel()
        {
            GetUsers();
            InsertCommand = new Command(Insert);
            UpdateCommand = new Command(Update);
            DeleteCommand = new Command(Delete);
            CancelarCommand = new Command(Cancelar);
            AddUserCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new UserPage());
            });
        }
        #endregion

        #region Commands
        public Command AddUserCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command InsertCommand { get; set; }
        public Command CancelarCommand { get; set; }
        #endregion

        #region Methods
        private async void Insert(object obj)
        {
            var Servi = new Services<Usuarios>();
            var user = new Usuarios();
            user.Nombre = Nombre;
            user.Apellido = Apellido;
            user.Sexo = Sexo;
            user.Edad = Edad;
            user.Peso = Peso;
            user.Estatura = Estatura;

            if (string.IsNullOrEmpty(user.Nombre))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe ingresar su nombre/s", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(user.Apellido))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe ingresar su apellido/s", "Aceptar");
                return;
            }
            if (user.Edad.Equals(0))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe ingresar su edad", "Aceptar");
                return;
            }
            else
            {
                if (user.Edad < 0)
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Su edad tiene que ser mayor a cero", "Aceptar");
                    return;
                }
            }
            if (user.Peso.Equals(0))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe ingresar su peso en libras", "Aceptar");
                return;
            }
            else
            {
                if (user.Peso < 0)
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Su peso tiene que ser mayor a cero", "Aceptar");
                    return;
                }
            }
            if (user.Estatura.Equals(0))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe ingresar su estatura", "Aceptar");
                return;
            }
            else
            {
                if (user.Estatura < 0)
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Su estatura tiene que tener datos mayor a cero", "Aceptar");
                    return;
                }
            }
            var result = await Servi.Insert(user);
            if (result == 1)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de Aviso", "Registro Guardado con exito!!!", "Aceptar");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de Aviso", $"Error al guardar", "Aceptar");
            }
        }

        private async void Update(object obj)
        {
            if (_users != null)
            {
                _users.Nombre = Nombre;
                _users.Apellido = Apellido;
                _users.Sexo = Sexo;
                _users.Edad = Edad;
                _users.Peso = Peso;
                _users.Estatura = Estatura;
                var Servi = new Services<Usuarios>();
                var result = await Servi.Update(_users);
                if (result == 1)
                {
                    await App.Current.MainPage.DisplayAlert("Mensaje de aviso", "Registro Actualizado con exito!!!", "Aceptar");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        private async void Delete(object obj)
        {
            var Servi = new Services<Usuarios>();
            var result = await Servi.Delete(_users);
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

        public async void GetUsers()
        {
            var Servi = new Services<Usuarios>();
            ListUsuarios = await Servi.GetAll();
        }
        #endregion

    }
}
