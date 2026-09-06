using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Course.Entities
{
    class Product
    {
        public string NameProduct { get; set; } = string.Empty;
        public double Price { get; set; }

        public Product()
        {           
        }
        public Product(string nameProduct, double price)
        {
            NameProduct = nameProduct;
            Price = price;
        }
    }
}
