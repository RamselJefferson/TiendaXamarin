using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public partial class Menuprincipal 
    {
        
      
        public Menuprincipal()
        {
            this.BindingContext = new ItemsViewModel();
            InitializeComponent();
            

        }

      
    }
}