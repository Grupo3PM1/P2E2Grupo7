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
    }
}