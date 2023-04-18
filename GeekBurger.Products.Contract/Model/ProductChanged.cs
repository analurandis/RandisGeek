using GeekBurger.Products.Contract.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Contract.Model
{
    public class ProductChanged
    {
        public ProductState State { get; set; }
        public ProductToGet Product { get; set; }
    }
}
