using GeekBurger.Products.Infra.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Infra.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private ProductsDbContext _context;

        public ProductsRepository(ProductsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsByStoreName(string storeName)
        {
            var products = _context.Products?.Where(product =>
                product.Store.Name.Equals(storeName,
                StringComparison.InvariantCultureIgnoreCase))
            .Include(product => product.Items);

            return products;
        }

        public bool Add(Product product)
        {
            product.ProductId = Guid.NewGuid();
            _context.Products.Add(product);
            return true;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetFullListOfItems()
        {
            return _context.Products?.Include(product => product.Items); ;
        }
    }
}
