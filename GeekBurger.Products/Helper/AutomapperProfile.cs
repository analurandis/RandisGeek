using AutoMapper;
using GeekBurger.Products.Contract.Mapper;
using GeekBurger.Products.Contract.Model;
using GeekBurger.Products.Infra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Product, ProductToGet>();
            CreateMap<Item, ItemToGet>();
            CreateMap<ProductToUpsert, Product>()
                .AfterMap<MatchStoreFromRepository>();
            CreateMap<ItemToUpsert, Item>()
                .AfterMap<MatchItemsFromRepository>();

        }

    }
}
