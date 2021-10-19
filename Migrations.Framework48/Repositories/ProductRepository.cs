using Migrations.Framework48.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Migrations.Framework48.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>();
        private static object _object = new object();
        public void Add(Product product)
        {
            lock (_object)
            {
                _products.Add(product);
            }
        }
        public Product Get(int id)
        {
            lock (_object)
            {
                return _products.FirstOrDefault(product => product.Id == id);
            }
        }

        public void Update(Product product)
        {
            lock (_object)
            {
                var _product = _products.FirstOrDefault(p => p.Id == product.Id);
                _product.Name = product.Name;
                _product.Price = product.Price;
                _product.Description = product.Description;
            }
        }

        public void Remove(Product product)
        {
            lock (_object)
            {
                _products.Remove(product);
            }
        }


        public IEnumerable<Product> Get()
        {
            return _products.ToArray();
        }
    }
}