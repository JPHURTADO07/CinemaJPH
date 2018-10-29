
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void Post(object sender, EventArgs e)
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var content = new StringContent("Usuario=" + admin.Text + "&Password=" + Password.Text, Encoding.UTF8, "application/json");

            var response = cliente.PostAsync("/api/Seguridad", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var respuestaJson = await response.Content.ReadAsStringAsync();
                var autentificacion = JsonConvert.DeserializeObject<Admin>(respuestaJson);
                if (autentificacion.EsPermitido == true)
                {
                    await DisplayAlert("Resultado", autentificacion.Mensaje, "Continuar");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Incorrecto", autentificacion.Mensaje, "Reintentar");
                }
            }
        }
    }
}