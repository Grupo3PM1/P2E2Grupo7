using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2GRUPO7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private async Task ValidationForm()
        {
            if (String.IsNullOrWhiteSpace(txtlatitud.Text) ||
                String.IsNullOrWhiteSpace(txtlongitud.Text) ||
                String.IsNullOrWhiteSpace(txtdescripcion.Text)
                )
            {
                await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios", "OK");
            }
        }

        private async void Toolbar01_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());

        }

        private async void Toolbar02_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new DirectionsPage());
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            if (ValidationForm().IsCompleted)
            {
                var sit = new Models.Sitio
                {
                    id = txtid.Text,
                    descripcion = txtdescripcion.Text,
                    latitud = txtlatitud.Text,
                    longitud = txtlongitud.Text
                };

                await Controllers.SitiosController.UpdateSitio(sit);
                await DisplayAlert("Logrado", "Actualizado Exitosamente", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar la ubicacion", "Ok");
            }

        }

        private void ClearScreen()
        {
            // this.txtlatitud.Text = String.Empty;
            //this.txtlongitud.Text = String.Empty;
            this.txtdescripcion.Text = String.Empty;
        }

    }
}