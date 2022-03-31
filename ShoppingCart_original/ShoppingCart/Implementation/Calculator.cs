using System.Collections.Generic;
using ShoppingCart.Interfaces;
using ShoppingCart.Pocos;
using System;

namespace ShoppingCart.Implementation
{
    public class Calculator
    {
        private readonly IRepository<Product> _productStore;
        private readonly IShippingCalculator _shippingCalculator;

        public Calculator(IShippingCalculator shippingCalculator, IRepository<Product> productStore)
        {
            _productStore = productStore;
            _shippingCalculator = shippingCalculator;
        }

        public double Total(IList<CartItem> cart)
        {
            throw new NotImplementedException("Cart total calculation not implemented");
        }
    }
}