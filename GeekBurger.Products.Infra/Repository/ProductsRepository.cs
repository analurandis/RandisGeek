using GeekBurger.Products.Infra.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Infra.Repository
{
    public class ProductsRepository : BaseRepository<Product>, IProductsRepository
    {
        private ProductsDbContext _context;

        public ProductsRepository(ProductsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            product.ProductId = Guid.NewGuid();
            await _context.Products.AddAsync(product);
            return true;
        }

        public async Task<Product> GetProductByFilters(Expression<Func<Product, bool>> filters)
        {
            var resultFilters = GetByFilters(true, filters);
            var product = await resultFilters.Include(p=> p.Items).FirstOrDefaultAsync() ;
            return product;
        }

        public async Task<List<Item>> GetFullListOfItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<List<Product>>
            GetProductsByStoreNameAsync(string storeName)
        {
            var products = await _context.Products?
            .Where(product =>
                product.Store.Name.Equals(storeName,
                StringComparison.InvariantCultureIgnoreCase))
            .Include(product => product.Items)
            .ToListAsync();

            return products;
        }

        public async Task<Store> GetStoreByName(string storeName)
        {
            return await _context.Stores?.FirstOrDefaultAsync(f => f.Name == storeName);
        }

    }
}
