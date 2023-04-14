
using GeekBurger.Products.Contract.Mapper;
using GeekBurger.Products.Contract.Model;

namespace GeekBurger.Products.Service.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductToGet>> GetProductsByStoreNameAsync(string storeName);
        Task<bool> Add(ProductToUpsert productToUpSert);
        Task<ProductToGet> GetProductById(Guid id);
    }
}
