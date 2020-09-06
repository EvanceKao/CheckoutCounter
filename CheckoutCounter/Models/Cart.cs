using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CheckoutCounter.Models
{
    public class Cart
    {
        private ConcurrentBag<Product> _products = new ConcurrentBag<Product>();

        public bool IsEmpty => _products.IsEmpty;

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Add(IEnumerable<Product> products)
        {
            products.AsParallel().ForAll(p => _products.Add(p));
        }

        public void Clear()
        {
            _products.Clear();
        }

        public void Update(IEnumerable<Product> products)
        {
            this.Clear();
            this.Add(products);
        }

        public IEnumerable<Product> GetProductsCopy()
        {
            return _products.ToList();
        }

    }
}
