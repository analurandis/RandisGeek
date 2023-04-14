using AutoMapper;
using GeekBurger.Products.Contract.Model;
using GeekBurger.Products.Infra.Model;
using GeekBurger.Products.Infra.Repository;


namespace GeekBurger.Products.Mapper
{
    public class MatchStoreFromRepository :IMappingAction<ProductToUpsert, Product>
    {
        private IProductsRepository _productsRepository;
        public MatchStoreFromRepository(IProductsRepository
            productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public void Process(ProductToUpsert source,Product destination)
        {
            var store =
                 _productsRepository.GetStoreByName(source.StoreName).Result;

            if (store != null)
                destination.StoreId = store.StoreId;
        }
    }
}