﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.Products.Service.Services
{
    public class ServiceBusConfiguration
    {
        public string ConnectionString { get; set; }
        public string ResourceGroup { get; set; }
        public string NamespaceName { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string SubscriptionId { get; set; }
        public string TenantId { get; set; }
    }
}
