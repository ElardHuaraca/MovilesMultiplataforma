using Lab15.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab15.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<Producto> Productos { get; private set; }
        
        public RestService()
        {
            client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecuretHandler());
        }
        
        public async Task<List<Producto>> RefreshDataAsync()
        {
            Productos = new List<Producto>();
            string action = "GET";
            var uri = new Uri(string.Format(Constants.RestURL, action));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Productos = JsonConvert.DeserializeObject<List<Producto>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return Productos;
        }

        public async Task SaveProductoAsync(Producto item, bool isNewItem)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    var uri = new Uri(string.Format(Constants.RestURL, "POST"));
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    var uri = new Uri(string.Format(Constants.RestURL, "PUT"));
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tProducto guardado correctamente.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: "+ex.Message);
            }
        }

        public async Task DeleteProductoAsync(string id)
        {
            var uri = new Uri(Constants.RestURL+id);
            Console.WriteLine("url: " + uri);
            try
            {
                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tProducto eliminado correctamente");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }
    }
}
