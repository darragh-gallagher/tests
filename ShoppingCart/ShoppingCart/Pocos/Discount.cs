using System;
namespace ShoppingCart.Pocos
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Percent { get; set; }
        public bool FreeShipping { get; set; }
        public int Supllier { get; set; }
        public int Category { get; set; }
    }
}
