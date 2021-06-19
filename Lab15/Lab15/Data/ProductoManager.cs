using Lab15.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab15.Data
{
    public class ProductoManager
    {
        IRestService restService;

        public ProductoManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Producto>> GetTaskAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Producto item, bool isNewItem = false)
        {
            return restService.SaveProductoAsync(item, isNewItem);
        }

        public Task DeleteTaskAsync(Producto item)
        {
            return restService.DeleteProductoAsync(item.codigo);
        }
    }
}
