using GeekBurger.Products.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Contract.Mapper
{
    public class MatchStoreFromRepository :IMappingAction<ProductToUpsert, Product>
    {
        private IStoreRepository _storeRepository;
        public MatchStoreFromRepository(IStoreRepository
            storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public void Process(ProductToUpsert source,
            Product destination)
        {
            var store =
                _storeRepository.GetStoreByName(source.StoreName);

            if (store != null)
                destination.StoreId = store.StoreId;
        }
    }
}