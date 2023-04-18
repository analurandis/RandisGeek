using GeekBurger.Products.Infra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Infra.Repository
{
    public interface IProductsRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GetProductsByStoreNameAsync(string storeName);
        Task<bool> AddProductAsync(Product product);
        Task<List<Item>> GetFullListOfItemsAsync();
        Task<Store> GetStoreByName(string storeName);
        Task<Product> GetProductByFilters(Expression<Func<Product, bool>> filters);
        void Save();
    }
}
