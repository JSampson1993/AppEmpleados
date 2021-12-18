using AppEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEmpleados.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var person = new Models.Empleado
            {

                codigo = Convert.ToInt32(codigo.Text),
                Nombre = nombre.Text,
                Apellidos = apellidos.Text,
                Edad = Convert.ToInt32(edad.Text),
                Direccion = direccion.Text,
                Puesto = puesto.Text

            };
            if (await App.BaseDatos.deleteAsync(person) != 0)
            {
                var mensaje = await DisplayAlert("Eliminar", "Desea Eliminar la nota4", "Si", "No");

                if (mensaje)
                {
                    await DisplayAlert("Alerta", "Empleado Eliminado Correctamente!!", "OK");
                    await Navigation.PushModalAsync(new ListaEmpleados());
                }
            }
            else
                await DisplayAlert("Eliminar Empleado", "Error al Eliminar Persona!!", "Ok");
            //await DisplayAlert // Convert.ToDateTime( this.DueDate.no),

        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(codigo.Text))
            {
                Empleado person = new Empleado()
                {

                    codigo = Convert.ToInt32(codigo.Text),
                    Nombre = nombre.Text,
                    Apellidos = apellidos.Text,
                    Edad = Convert.ToInt32(edad.Text),
                    Direccion = direccion.Text,
                    Puesto = puesto.Text

                };
                await App.BaseDatos.SaveTaskAsync(person);

                await DisplayAlert("Alert", "Datos Actualizado Correctamente", "OK");
                await Navigation.PushModalAsync(new ListaEmpleados());

            }
            else
            {
                await DisplayAlert("Alert", "Error", "OK");
            }
        }
    
    }
}