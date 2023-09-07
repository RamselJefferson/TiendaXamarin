using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
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

        

        public  List<Items> GetItems(string search = "")
        {
           

            try
            {
                HttpClientHandler insecureHandler = GetInsecureHandler();
                HttpClient client = new HttpClient(insecureHandler);
                if (string.IsNullOrEmpty(search))
                {
                    var response = client.GetAsync("http://10.0.20.55:44325/Items").GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync();
                        List<Items> items = JsonConvert.DeserializeObject<List<Items>>(content.Result);
                        return items;
                    }
                    else
                    {
                        
                        return null;
                    }
                }
                else
                {
                    var response =  client.GetAsync($"http://10.0.20.55:44325/Items/SearchItemsFilter?search={search}").GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var content =  response.Content.ReadAsStringAsync();
                        List<Items> items = JsonConvert.DeserializeObject<List<Items>>(content.Result);
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
