using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Interfaces;
using ShoppingCart.Pocos;

namespace ShoppingCart.Implementation
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly List<Category> _category = new List<Category>();
        public void Add(Category item)
        {
            _category.Add(item);
        }

        public Category Get(int id)
        {
            return _category.FirstOrDefault(x => x.Id == id);
        }

        public Category GetFromID(int id)
        {
            return _category.FirstOrDefault(x => x.Id == id);
        }

        public Category GetStringID(string name)
        {
            return _category.FirstOrDefault(x => x.Name == name);
        }
    }
}
