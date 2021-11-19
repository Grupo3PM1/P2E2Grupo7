using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2GRUPO7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.MainPage());
            //MainPage = new NavigationPage(new Views.DirectionsPage());
            //MainPage = new NavigationPage(new Views.UpdatePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
