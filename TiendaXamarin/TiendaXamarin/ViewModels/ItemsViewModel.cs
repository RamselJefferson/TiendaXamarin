using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TiendaXamarin.Droid;
using TiendaXamarin.Ds;
using TiendaXamarin.Modelo;

using TiendaXamarin.Services;
using Xamarin.Forms;
[assembly: Xamarin.Forms.Dependency(typeof(ItemsViewModel))]
namespace TiendaXamarin.Ds
{
 
    public class ItemsViewModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;


        private static List<Items> _itemList;
        private readonly ApiManager api;

        private static ItemsViewModel _instance;
        public List<Items> itemsList { get => _itemList; set { _itemList = value;  OnPropertyChanged(); }  }

        public ItemsViewModel()
        {
            if (api == null)
            {
                api = new ApiManager();
            }
            if (_itemList == null)
            {
                GetItems();
            }

            _instance = this;
            
        }

        public static ItemsViewModel Instance()
        {
           
            return _instance;
        }


        public List<Items> GetItems(string prueba = "")
        {

           
            
            if (string.IsNullOrEmpty(prueba))
            {

                var itemsListPrueba = api.GetItems();
                itemsList = itemsListPrueba;
                return itemsListPrueba;
                
            }
            else
            {
                var list = api.GetItems(prueba);
                
                itemsList = list;
                return itemsList;
            }

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
