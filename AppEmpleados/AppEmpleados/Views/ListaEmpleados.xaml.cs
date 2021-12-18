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
    public partial class ListaEmpleados : ContentPage
    {
        public ListaEmpleados()
        {
            InitializeComponent();
        }
        private async void ListaPrecios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Empleado item = (Models.Empleado)e.Item;
            /// await DisplayAlert("Elemento Tocado " , "Descripcion: " + item.Descripcion, "Ok");

            var page = new UpdatePage();
            page.BindingContext = item;
            await Navigation.PushModalAsync(page);
        }
    }
}