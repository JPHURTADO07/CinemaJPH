
using CineJPH07.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_PJOH.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            listaPeliculas();
        }

        private async void listaPeliculas()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");
            var request = await cliente.GetAsync("/api/Cartelera");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var cartelera = JsonConvert.DeserializeObject<List<Cartelera>>(responseJson);
                listaCartelera.ItemsSource = cartelera;
            }
        }

        private async void ubicarPelicula(object sender, SelectedItemChangedEventArgs e)
        {
            var cartelera = e.SelectedItem as Cartelera;
            await Navigation.PushAsync(new FuncionesPage(cartelera));

        }
    }
}