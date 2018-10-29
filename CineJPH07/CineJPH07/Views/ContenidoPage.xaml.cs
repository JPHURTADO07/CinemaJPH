using CineJPH07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_PJOH.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContenidoPage : ContentPage
    {
        public ContenidoPage(Funciones funciones, Cartelera cartelera, int valor)
        {
            int total = valor * (funciones.Precio);
            InitializeComponent();
            stackLayout.BindingContext = funciones;
            cartelerajp.BindingContext = cartelera;
            miLabel.Text = Convert.ToString(valor);
            lbltotal.Text = Convert.ToString(total);
        }

        private void Confirmar(object sender, EventArgs e)
        {
            DisplayAlert("Reserva", "La reserva se ha generado correctamente", "Continuar");
        }
    }
}