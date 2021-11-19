using Plugin.Geolocator;
using PM2E2GRUPO7.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Reflection;
using System.IO;
using Plugin.Media;

using Xamarin.Essentials;

namespace PM2E2GRUPO7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public bool takedfoto = false;
        public byte[] imgbyte;
        public Image image = new Image();

        public MainPage()
        {
            InitializeComponent();
            Conexion();
            //Ubicacion();
            TakePhoto.Clicked += TakePhoto_Clicked;
        }

        //INICIO VALIDACION DE CONEXION A INTERNET
        private async void Conexion()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                await DisplayAlert("Bienvenido", "Cuenta con Internet", "Ok");
                Ubicacion();
            }
        }//FIN


        // INICIO UBICACION
        private async void Ubicacion()
        {
            if (!CrossGeolocator.IsSupported)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al cargar el plugin", "OK");
                return;
            }

            if (CrossGeolocator.Current.IsGeolocationEnabled)
            {
                CrossGeolocator.Current.PositionChanged += Current_PositionChanged;

                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 1), 0.5);

            }
            else
            {
                await DisplayAlert("Error", "El GPS no esta activo en este dispositivo", "OK");
            }
            
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            if (!CrossGeolocator.Current.IsListening)
            {

                return;
            }
            var position = CrossGeolocator.Current.GetPositionAsync();

            txtlatitud.Text = position.Result.Latitude.ToString();
            txtlongitud.Text = position.Result.Longitude.ToString();
        }

        private async Task ValidationForm()
        {
            if (String.IsNullOrWhiteSpace(txtlatitud.Text) ||
                String.IsNullOrWhiteSpace(txtlongitud.Text) ||
                String.IsNullOrWhiteSpace(txtdescripcion.Text) ||
                takedfoto == false)
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
                    descripcion = txtdescripcion.Text,
                    latitud = txtlatitud.Text,
                    longitud = txtlongitud.Text
                };

                await Controllers.SitiosController.CrearSitio(sit);
                ClearScreen();
                await DisplayAlert("Salvado", "Guardado Exitosamente", "Ok");
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
            Photo.Source = ImageSource.FromFile("noimagen.png");
            takedfoto = false;
        }

        private async void BtnUbicacion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DirectionsPage());
        }
        // FIN UBICACION

        // INICIO CAMARA
        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var photo =
               await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());
            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() =>
                {

                    takedfoto = true;
                    image.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                    using (MemoryStream memory = new MemoryStream())
                    {

                        Stream stream = photo.GetStream();
                        stream.CopyTo(memory);
                        imgbyte = memory.ToArray();
                    }
                    return photo.GetStream();
                });
            }
            else
            {
                await DisplayAlert("Error", "No hay foto", "OK");
            }
        }
        // FIN CAMARA
    }
}