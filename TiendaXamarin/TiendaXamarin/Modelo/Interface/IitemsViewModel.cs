
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaXamarin.Modelo;

namespace TiendaXamarin.Droid
{ 
        public interface IitemsViewModel : INotifyPropertyChanged
        {
            List<Items> GetItems(string prueba = "");
        }
    
}