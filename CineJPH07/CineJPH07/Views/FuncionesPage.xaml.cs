

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
    public partial class FuncionesPage : ContentPage
    {
        Cartelera globalcar;
        public FuncionesPage(Cartelera cartelera)
        {
            InitializeComponent();
            BindingContext = cartelera;
            listFunciones.ItemsSource = cartelera.Funciones;
            globalcar = cartelera;
        }
        private async void Selected_Funcion(object sender, SelectedItemChangedEventArgs e)
        {
            int valor = Convert.ToInt32(MiEntry.Text);
            var funcion = e.SelectedItem as Funciones;
            await Navigation.PushAsync(new ContenidoPage(funcion, globalcar, valor));
        }
    }
}