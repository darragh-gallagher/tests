using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Interfaces;
using ShoppingCart.Pocos;

namespace ShoppingCart.Implementation
{
    public class DiscountRepository : IRepository<Discount>
    {
        private readonly List<Discount> _discounts = new List<Discount>();

        public void Add(Discount item)
        {
            _discounts.Add(item);
        }

        //Get category discount
        public Discount Get(int id)
        {
            return _discounts.FirstOrDefault(x => x.Category == id);
        }

        //Get supplier discount
        public Discount GetFromID(int id)
        {
            return _discounts.FirstOrDefault(x => x.Supllier == id);
        }

        //Get discount by code
        public Discount GetStringID(string code)
        {
            return _discounts.FirstOrDefault(x => x.Code == code);
        }

        
        
    }
}
