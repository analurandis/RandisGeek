using AutoMapper;
using GeekBurger.Products.Contract.Mapper;
using GeekBurger.Products.Contract.Model;
using GeekBurger.Products.Infra.Model;
using GeekBurger.Products.Infra.Repository;
using GeekBurger.Products.Service.Interfaces;

namespace GeekBurger.Products.Service.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductsRepository _productsRepository;
        private IMapper _mapper;

        public ProductService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(ProductToUpsert productToUpSert)
        {
            var product = _mapper.Map<Product>(productToUpSert);
            bool inserted =  await _productsRepository.AddProductAsync(product);
            await _productsRepository.SaveAsync();

            return inserted;
        }

        public async Task<ProductToGet> GetProductById(Guid id)
        {
            var productDb = await _productsRepository.GetProductByFilters(f => f.ProductId == id);
            var productMap = _mapper.Map<ProductToGet>(productDb);

            return productMap;
        }

        public async Task<List<ProductToGet>> GetProductsByStoreNameAsync(string storeName)
        {
            var productsByStore = await _productsRepository.GetProductsByStoreNameAsync(storeName);

            var productsToGet = _mapper.Map<List<ProductToGet>>(productsByStore);

            return productsToGet;
        }
    }
}
