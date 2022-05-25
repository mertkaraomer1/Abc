using Abc.MvcWebUI.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }
        public void AddProduct(product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if(line==null)
            {
                _cartLines.Add(new CartLine() { Product = product, Qantity = quantity });
            }
            else
            {
                line.Qantity += quantity;
            }
        }

        public void DeleteProduct(product product)
        {
            _cartLines.RemoveAll(i => i.Product.Id == product.Id);
        }


        public double total()
        {
            return _cartLines.Sum(i => i.Product.Price * i.Qantity);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }
    }
    public class CartLine
    {
        public product Product { get; set; }
        public int Qantity { get; set; }
    }
}