

namespace ShoppingCart.Pocos
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int[] CategoryId { get; set; }
        public int supllierId { get; set; }
    }
}
