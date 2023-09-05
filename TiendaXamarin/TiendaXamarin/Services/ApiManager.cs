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

        

        public async  Task<List<Items>> GetItems(string search = "")
        {
           

            try
            {
                HttpClientHandler insecureHandler = GetInsecureHandler();
                HttpClient client = new HttpClient(insecureHandler);
                if (string.IsNullOrEmpty(search))
                {
                    var response = await client.GetAsync("https://10.0.20.55:44325/Items");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        List<Items> items = JsonConvert.DeserializeObject<List<Items>>(content);
                        return items;
                    }
                    else
                    {
                        
                        return null;
                    }
                }
                else
                {
                    var response = await client.GetAsync($"https://10.0.20.55:44325/Items/SearchItemsFilter?search={search}");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        List<Items> items = JsonConvert.DeserializeObject<List<Items>>(content);
                        return items;
                    }
                    else
                    {
                        
                        return null;
                    }
                }
               
            }
            catch (Exception ex)
            {
                
                return null;
            }

        }


   


    }
}
