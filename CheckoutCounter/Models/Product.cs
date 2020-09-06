using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutCounter.Models
{
    public class Product
    {
        public int Id;
        public string SKU;
        public string Name;
        public decimal Price;
        public HashSet<string> Tags;
    }
}
