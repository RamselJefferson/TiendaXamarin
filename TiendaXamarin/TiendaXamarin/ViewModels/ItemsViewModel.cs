using Amazon.DynamoDBv2.DocumentModel;
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
[assembly: Xamarin.Forms.Dependency(typeof(ItemsViewModel))]
namespace TiendaXamarin.Ds
{
 
    public class ItemsViewModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<vwItems> _itemList;
        private readonly ApiManager api;

        private static ItemsViewModel _instance;
        public ObservableCollection<vwItems> itemsList { get => _itemList; set { _itemList = value;  OnPropertyChanged(); }  }

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


        public ObservableCollection<vwItems> GetItems(string prueba = "")
        {
    
            if (string.IsNullOrEmpty(prueba))
            {

                itemsList = api.GetItems();
                return itemsList;
                
            }
            else
            {

                itemsList.Clear();
                var list = api.GetItems(prueba);  

                if(list != null)
                {
                    foreach (var item in list)
                    {
                        Task.Delay(100);
                        itemsList.Add(item);
                       
                    }

        
                }
               
                return itemsList;
            }


        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
