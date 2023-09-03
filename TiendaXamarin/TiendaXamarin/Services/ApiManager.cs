using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TiendaXamarin.Modelo;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TiendaXamarin.Services
{
    public class ApiManager
    {
        private HttpClient client1;


        private HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public async  Task<ObservableCollection<Items>> GetItems()
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();
            HttpClient client = new HttpClient(insecureHandler);




            try
            {
                var response = await client.GetAsync("https://192.168.0.104:7126/Items");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ObservableCollection<Items> items = JsonConvert.DeserializeObject<ObservableCollection<Items>>(content);
                    return items;
                }
                else
                {
                    // Manejar el caso de respuesta no exitosa
                    return null;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }

        }
   


    }
}
