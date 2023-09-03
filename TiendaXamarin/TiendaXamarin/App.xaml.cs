using System;
using TiendaXamarin.vistas.Menuprincipal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiendaXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Menuprincipal();
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
