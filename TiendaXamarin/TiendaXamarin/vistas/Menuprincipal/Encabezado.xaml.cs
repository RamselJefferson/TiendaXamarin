using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TiendaXamarin.Ds;
using TiendaXamarin.Modelo;
using TiendaXamarin.Modelo.Interface;
using TiendaXamarin.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiendaXamarin.vistas.Menuprincipal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Encabezado : ContentView
    {

        private ItemsViewModel items;

        public Encabezado()
        {
            
            InitializeComponent();

        }
        
        private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
       {
            string searchTerm = e.NewTextValue.ToLower();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                items = new ItemsViewModel(searchTerm);

            }
           
        }


    }
}