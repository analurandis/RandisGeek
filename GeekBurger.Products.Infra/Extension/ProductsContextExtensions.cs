﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GeekBurger.Products.Infra.Model;
using GeekBurger.Products.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.Products.Infra.Extension
{
    public static class ProductsContextExtensions
    {
        public static void Seed(this ProductsDbContext context)
        {
            context.Items.RemoveRange(context.Items);
            context.Products.RemoveRange(context.Products);
            context.Stores.RemoveRange(context.Stores);

            context.SaveChanges();
            context.Stores.AddRange(
                 new List<Store> {
                            new Store { Name = "Paulista",
                            StoreId = new Guid("8048e9ec-80fe-4bad-bc2a-e4f4a75c834e") },
                            new Store { Name = "Morumbi",
                            StoreId = new Guid("8d618778-85d7-411e-878b-846a8eef30c0") }
                });

           context.SaveChanges();
        }
    }
}
