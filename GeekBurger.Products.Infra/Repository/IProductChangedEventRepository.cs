using System;
using GeekBurger.Products.Infra.Model;

namespace GeekBurger.Products.Infra.Repository
{
    public interface IProductChangedEventRepository
    {
        ProductChangedEvent Get(Guid eventId);
        bool Add(ProductChangedEvent productChangedEvent);
        bool Update(ProductChangedEvent productChangedEvent);
        void Save();
    }
}
