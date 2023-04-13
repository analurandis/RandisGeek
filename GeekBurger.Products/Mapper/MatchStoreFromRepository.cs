using AutoMapper;
using GeekBurger.Products.Contract;
using GeekBurger.Products.Contract.Model;
using GeekBurger.Products.Infra.Model;
using GeekBurger.Products.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Products.Mapper
{
    public class MatchStoreFromRepository :IMappingAction<ProductToUpsert, Store>
    {
        private IStoreRepository _storeRepository;
        public MatchStoreFromRepository(IStoreRepository
            storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public void Process(ProductToUpsert source, Store destination, ResolutionContext context)
        {
            var store = _storeRepository.GetStoreByStoreName(source.StoreName);

            if (store != null)
                destination.StoreId = store.StoreId;
        }
    }
}