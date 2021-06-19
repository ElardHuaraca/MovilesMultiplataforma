using Lab15.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab15.Data
{
    public interface IRestService
    {
        Task<List<Producto>> RefreshDataAsync();
        Task SaveProductoAsync(Producto item, bool isNewItem);
        Task DeleteProductoAsync(string id);
    }
}
