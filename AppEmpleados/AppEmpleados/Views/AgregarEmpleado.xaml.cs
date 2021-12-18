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
    public partial class AgregarEmpleado : ContentPage
    {
        public AgregarEmpleado()
        {
            InitializeComponent();
        }

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaEmpleados());
        }
    }
}