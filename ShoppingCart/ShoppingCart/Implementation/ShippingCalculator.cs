using ShoppingCart.Interfaces;
using System;

namespace ShoppingCart.Implementation
{
    public class ShippingCalculator : IShippingCalculator
    {
        public double CalcShipping(double cartTotal, bool freeShipping)
        {
            //Standard rate 
            double ship = 7.0;

            //Check for discount
            if(cartTotal > 20)
            {ship = 5.0;}

            if (cartTotal > 40)
            {ship = 0.0;}

            //Check for free shipping in discount
            if(freeShipping == true)
            { ship = 0.0; }

            return ship;
        }
    }
}