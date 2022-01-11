using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreDoodle.Data
{
    public interface IProductData
    {
        IEnumerable<Product> GetProducts();

        IEnumerable<Product> GetProducts(string searchTerm);
        Product GetProduct(int id);
    }
}
