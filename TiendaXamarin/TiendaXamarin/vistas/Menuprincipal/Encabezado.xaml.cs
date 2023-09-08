using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TiendaXamarin.Droid;
using TiendaXamarin.Ds;
using TiendaXamarin.Modelo;

using TiendaXamarin.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TiendaXamarin.vistas.Menuprincipal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Encabezado : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _search;
        public string search { get => _search; set { _search = value; OnPropertyChanged(); } }
        public Encabezado()
        {
            BindingContext = this;
       
            InitializeComponent();

        }
        


        private   void Button_Clicked(object sender, EventArgs e)
        {

            ItemsViewModel.Instance().GetItems(search);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}