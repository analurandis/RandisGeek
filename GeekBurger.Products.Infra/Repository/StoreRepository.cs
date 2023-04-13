using GeekBurger.Products.Infra.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Infra.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ProductsDbContext _context;

        public StoreRepository(ProductsDbContext productsDbContext)
        {
            this._context = productsDbContext;
        }

        public Store GetStoreByStoreName(string storeName)
        {
            var store = _context.Stores?.FirstOrDefault(store =>
                store.Name.Equals(storeName,
                StringComparison.InvariantCultureIgnoreCase));

            return store;
        }
    }
}
