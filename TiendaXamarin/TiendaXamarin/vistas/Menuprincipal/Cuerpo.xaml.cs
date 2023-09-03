using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaXamarin.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiendaXamarin.vistas.Menuprincipal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cuerpo : ContentView
    {
        private ApiManager apiManager;
        public Cuerpo()
        {
            apiManager = new ApiManager();
            apiManager.GetItems();
            InitializeComponent();

        }
    }
}