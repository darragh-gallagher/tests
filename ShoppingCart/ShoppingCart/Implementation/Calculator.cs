using System.Collections.Generic;
using ShoppingCart.Interfaces;
using ShoppingCart.Pocos;
using System;
using System.Linq;

namespace ShoppingCart.Implementation
{
    public class Calculator
    {
        private readonly IRepository<Product> _productStore;
        private readonly IRepository<Discount> _discountStore;
        private readonly IShippingCalculator _shippingCalculator;
        

        public Calculator(IShippingCalculator shippingCalculator, IRepository<Product> productStore, IRepository<Discount> discountStore)
        {
            _productStore = productStore;
            _discountStore = discountStore;
            _shippingCalculator = shippingCalculator;
        }

        public double [] GetTotalAndShiping(IList<CartItem> cart, string discountCode)
        {
            double total = 0.00;
            bool freeShipping = false;

            //Assign default discount variables for invalid codes
            double DisPer = 1.0;
            int DisCategory = 0;
            int DisSupplier = 0;

            var Discount = _discountStore.GetStringID(discountCode);

            //Check for valid discount code
            if(Discount != null)
            {
                DisPer = Discount.Percent;
                DisCategory = Discount.Category;
                DisSupplier = Discount.Supllier;
                if (Discount.FreeShipping == true) { freeShipping = true; }
            }

            foreach (var c in cart)
            {
                //Get product and price
                var product = _productStore.Get(c.ProductId);
                var price = product.Price;

                //Adjust price for unit quantity
                if(c.UnitQuantity > 1) { price = price * c.UnitQuantity; }

                //Check if categories match discount category
                int[] categories = product.CategoryId;
                foreach (var v in categories)
                {
                    if (v == DisCategory)
                    {
                        //Add discount to cart item
                        price *= DisPer;
                    }
                }

                //Check if supplier match discount category
                if (product.supllierId == DisSupplier)
                {
                    //Add discount to cart item
                    price *= DisPer;
                }

                //Add to cart total
                total += price;              
            }

            //Get shipping cost
            var shipping = _shippingCalculator.CalcShipping(total, freeShipping);

            double[] ShipTotal = { total, shipping };

            return ShipTotal;
        }


    }
}