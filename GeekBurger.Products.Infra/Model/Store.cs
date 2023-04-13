using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Infra.Model
{
    public class Store
    {
        [Key]
        public Guid StoreId { get; set; }
        public string Name { get; set; }

    }
}
