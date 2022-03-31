using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Interfaces;
using ShoppingCart.Pocos;

namespace ShoppingCart.Implementation
{
    public class SupplierRepository : IRepository<Supplier>
        {
            private readonly List<Supplier> _suppliers = new List<Supplier>();
            public void Add(Supplier item)
            {
                _suppliers.Add(item);
            }

            public Supplier Get(int id)
            {
                return _suppliers.FirstOrDefault(x => x.Id == id);
            }

            public Supplier GetFromID(int id)
            {
                return _suppliers.FirstOrDefault(x => x.Id == id);
            }

            public Supplier GetStringID(string name)
            {
                return _suppliers.FirstOrDefault(x => x.Name == name);
            }
       
    }
}
