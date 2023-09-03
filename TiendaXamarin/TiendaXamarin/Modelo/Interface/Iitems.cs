using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace TiendaXamarin.Modelo.Interface
{
    public interface Iitems
    {
        Task<ObservableCollection<Items>> GetItems(string prueba = "");
    }
}
