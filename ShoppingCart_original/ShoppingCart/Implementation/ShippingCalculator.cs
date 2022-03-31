using ShoppingCart.Interfaces;
using System;

namespace ShoppingCart.Implementation
{
    public class ShippingCalculator : IShippingCalculator
    {
        public double CalcShipping(double cartTotal)
        {
            throw new NotImplementedException("Shipping calculation not implemented");
        }
    }
}