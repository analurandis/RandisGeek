using GeekBurger.Products.Infra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Infra.Repository
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetFullListOfItems();
        IEnumerable<Product> GetProductsByStoreName(string storeName);
    }
}
