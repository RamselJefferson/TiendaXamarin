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

        private List<Items> _itemList;
        public List<Items> itemsList { get => _itemList; set { _itemList = value; OnPropertyChanged(); }  }

        public ItemsViewModel(string item = "")
        {
            apiManager = new ApiManager();
            GetItems(item);
        }



        

        public async Task<List<Items>> GetItems(string prueba = "")
        {
            if (string.IsNullOrEmpty(prueba))
            {
                _itemList = await apiManager.GetItems();
                return _itemList;
                
            }
            else
            {
                var list = await apiManager.GetItems(prueba);
                _itemList.Clear();
                _itemList.AddRange(list);
                return _itemList;
            }

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
