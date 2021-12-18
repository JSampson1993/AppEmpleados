using AppEmpleados.Views;
using Examen_3.ViewModels;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEmpleados
{
    public partial class App : Application
    {
        static ArticulosMVVM basedatos;

        public static ArticulosMVVM BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new ArticulosMVVM(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empleados"));
                }
                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AgregarEmpleado());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
