using Migrations.Framework48.Domain;
using System.Collections.Generic;

namespace Migrations.Framework48.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product Get(int id);

        IEnumerable<Product> Get();
        void Remove(Product product);
        void Update(Product product);
    }
}