using AutoMapper;
using GeekBurger.Products.Contract.Model;
using GeekBurger.Products.Infra.Model;
using GeekBurger.Products.Infra.Repository;

namespace GeekBurger.Products.Mapper
{
    public class MatchItemsFromRepository :IMappingAction<ItemToUpsert, Item>
    {
        private IProductsRepository _productRepository;
        public MatchItemsFromRepository(IProductsRepository
            productRepository)
        {
            _productRepository = productRepository;
        }

        public void Process(ItemToUpsert source, Item destination)
        {
            var fullListOfItems =
                            _productRepository.GetFullListOfItemsAsync().Result;

            var itemFound = fullListOfItems?
                .FirstOrDefault(item => item.Name
                .Equals(source.Name,
                    StringComparison.InvariantCultureIgnoreCase));

            if (itemFound != null)
                destination.ItemId = itemFound.ItemId;
            else
                destination.ItemId = Guid.NewGuid();

        }

    }

}
