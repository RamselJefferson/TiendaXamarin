using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TiendaXamarin.Modelo;
using TiendaXamarin.Modelo.Interface;
using TiendaXamarin.Services;
using Xamarin.Forms;

namespace TiendaXamarin.Ds
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        private readonly ApiManager apiManager;
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Items> ItemsList;
        public ObservableCollection<Items> itemsList { get => ItemsList; set { ItemsList = value; OnPropertyChanged(nameof(itemsList)); }  }

        public ItemsViewModel()
        {
            apiManager = new ApiManager();
            GetItems();
        }



        

        public async Task<ObservableCollection<Items>> GetItems(string prueba = "")
        {
            if (string.IsNullOrEmpty(prueba))
            {
                itemsList = await apiManager.GetItems();
                return itemsList;
                
            }
            else
            {
                 itemsList = await apiManager.GetItems(prueba);
                return itemsList;
            }

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
