using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GeekBurger.Products.Infra.Model
{
    public class ProductChangedEvent
    {
        [Key]
        public Guid EventId { get; set; }

        public ProductState State { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public bool MessageSent { get; set; }
    }
}
