using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2GRUPO7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectionsPage : ContentPage
    {
        public DirectionsPage()
        {
            InitializeComponent();
        }

       /* protected async override void OnAppearing()
        {
            base.OnAppearing();

            List<Models.Sitio> sit = await PM2E2GRUPO7.Controllers.SitiosController.GetListSitios();
            list.ItemsSource = sit;
        }*/

        private async void btnRestApi_Clicked(object sender, EventArgs e)
        {
            List<Models.Sitio> sit = await PM2E2GRUPO7.Controllers.SitiosController.GetListSitios();
            list.ItemsSource = sit;

        }

       

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            var ubicacion = list.SelectedItem as Models.Sitio;
            if (ubicacion != null)
            {


                var page = new Views.UpdatePage();
                page.BindingContext = ubicacion;
                await Navigation.PushAsync(page);

            }
            else
            {
                await DisplayAlert("Alerta", "Seleccione un registro", "Ok");
            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var ubicacion = list.SelectedItem as Models.Sitio;
            if (ubicacion != null)
            {

                bool answer = await DisplayAlert("Alerta", "¿Desea Eliminar el registro seleccionado? Esto puede generar conflictos", "Yes", "No");
                Debug.WriteLine("Answer: " + answer);
                if (answer == true)
                {
                    //METODO DELETE
                    list.ItemsSource = "";
                }

            }
            else
            {
                await DisplayAlert("Alerta", "Seleccione un registro", "Ok");
            }
        }

        private void btnforusquare_Clicked(object sender, EventArgs e)
        {

        }
    }
}