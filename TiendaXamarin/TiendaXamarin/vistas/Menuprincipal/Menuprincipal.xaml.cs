using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaXamarin.Modelo;
using TiendaXamarin.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiendaXamarin.vistas.Menuprincipal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menuprincipal : ContentPage
    {
        private ApiManager apiManager;

        public ObservableCollection<Items> itemsList { get; set; }

        public Menuprincipal()
        {

            InitializeComponent();
            apiManager = new ApiManager();
            BindingContext = this;
            InitializeData();
        }

        private async void InitializeData()
        {
            itemsList = await GetItems();
            OnPropertyChanged(nameof(itemsList));
        }

        public async Task<ObservableCollection<Items>> GetItems()
        {
            var items = await apiManager.GetItems();
            return new ObservableCollection<Items>(items);
        }
    }
}