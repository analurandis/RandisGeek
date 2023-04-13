﻿using AutoMapper;
using GeekBurger.Products.Contract;
using GeekBurger.Products.Contract.Model;
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

        }

        public void Process(ItemToUpsert source, Item destination, ResolutionContext context)
        {
            var fullListOfItems =
                _productRepository.GetFullListOfItems();

            var itemFound = fullListOfItems?
                .FirstOrDefault(item => item.Name
                .Equals(source.Name,
                    StringComparison.InvariantCultureIgnoreCase));
            /*
            if (itemFound != null)
               // destination.ItemId = itemFound.Items.FirstOrDefault(p=> p.ItemId);
            else
                destination.ItemId = Guid.NewGuid();*/
        }
    }

}
