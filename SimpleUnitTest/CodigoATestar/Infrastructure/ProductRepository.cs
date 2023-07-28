using SimpleUnitTest.CodigoATestar.Domain.Contracts;
using SimpleUnitTest.CodigoATestar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest.CodigoATestar.Infrastructure
{
    internal class ProductRepository : IRepository<Product>
    {
        private readonly Dictionary<int, Product> _products;

        public ProductRepository()
        {
            _products = new Dictionary<int, Product>();
        }

        public void Create(Product product)
        {
            if (_products.ContainsKey(product.Id)) throw new Exception("Duplicidade de chave.");
            _products[product.Id] = product;
        }

        public Product GetById(int id)
        {
            if (!_products.ContainsKey(id)) throw new Exception("Não encontrado.");
            return _products[id];
        }

        public int GetSequence()
        {
            return _products.Count == 0 ? 1 : _products.Keys.Max() + 1;
        }
    }
}
