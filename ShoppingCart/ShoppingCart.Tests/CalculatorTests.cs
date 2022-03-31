using System.Collections.Generic;
using NUnit.Framework;
using ShoppingCart.Implementation;
using ShoppingCart.Pocos;

namespace ShoppingCart.Tests
{
    public class Tests
    {
        private ProductRepository _productRepository;
        private DiscountRepository _discountRepository;
        private CategoryRepository _categoryRepository;
        private SupplierRepository _suplierRepository;

        [SetUp]
        public void Init()
        {
            // sample suppliers
            var apple = new Supplier { Id = 1, Name = "Apple"};
            var dell = new Supplier { Id = 2, Name = "Dell" };
            var hp = new Supplier { Id = 3, Name = "HP" };

            // sample categories
            var electronics = new Category { Id = 1, Name = "Electronics" };
            var accessories = new Category { Id = 2, Name = "Accessories" };
            var audio = new Category { Id = 3, Name = "Audio" };

            // sample discounts
            var AUDIO10 = new Discount { Id = 1, Code = "AUDIO10", Percent = 0.9, FreeShipping = false, Supllier = 0, Category = 3};
            var APPLE5 = new Discount { Id = 2, Code = "APPLE5", Percent = 0.95, FreeShipping = false, Supllier = 1, Category = 0};
            var FREESHIPPING = new Discount { Id = 3, Code = "FREESHIPPING", Percent = 1.0, FreeShipping = true, Supllier = 0, Category = 0 };
            
            // sample products
            int[] usbCats = { 2 };
            var usbCable = new Product { Id = 1, Name = "USB Cable",  Price = 4 , CategoryId = usbCats, supllierId = 1 };
            int[] headCats = {1,2,3};
            var headphones = new Product { Id = 2, Name = "Headphones", Price = 10, CategoryId = headCats, supllierId = 1 };
            int[] lapCats = {1};
            var laptop = new Product { Id = 3, Name = "Laptop", Price = 1000, CategoryId = lapCats, supllierId = 2 };
            int[] monitorCats = {1};
            var monitor = new Product { Id = 4, Name = "Monitor", Price = 100, CategoryId = monitorCats, supllierId = 3};
            
            
            // create sample repositories and add items
            _productRepository = new ProductRepository();
            _productRepository.Add(usbCable);
            _productRepository.Add(headphones);
            _productRepository.Add(laptop);
            _productRepository.Add(monitor);

            _categoryRepository = new CategoryRepository();
            _categoryRepository.Add(electronics);
            _categoryRepository.Add(accessories);
            _categoryRepository.Add(audio);

            _discountRepository = new DiscountRepository();
            _discountRepository.Add(AUDIO10);
            _discountRepository.Add(APPLE5);
            _discountRepository.Add(FREESHIPPING);

            _suplierRepository = new SupplierRepository();
            _suplierRepository.Add(apple);
            _suplierRepository.Add(hp);
            _suplierRepository.Add(dell);
            
        }

        [Test]
        public void WithDiscount_AUDIO10_CheckCalculation()
        {
            var headphones = new CartItem { ProductId = 2, UnitQuantity = 2 }; 
            var usb = new CartItem { ProductId = 1, UnitQuantity = 1};
            var mointor = new CartItem { ProductId = 4, UnitQuantity = 1};
            var laptop = new CartItem { ProductId = 3, UnitQuantity = 1};

            var cart = new List<CartItem> { headphones, usb, mointor, laptop };
            
            var calc = new Calculator(new ShippingCalculator(), _productRepository, _discountRepository);

            double [] totalArray = calc.GetTotalAndShiping(cart, "AUDIO10");

            var shipping = totalArray[1];
            var total = totalArray[0];

            System.Console.WriteLine(total);
            System.Console.WriteLine(shipping);

            total += shipping;

            Assert.AreEqual(1122, total);
        }

        [Test]
        public void WithDiscount_APPLE5_CheckCalculation()
        {
            var headphones = new CartItem { ProductId = 2, UnitQuantity = 2 };
            var usb = new CartItem { ProductId = 1, UnitQuantity = 1 };
            var mointor = new CartItem { ProductId = 4, UnitQuantity = 1 };
            var laptop = new CartItem { ProductId = 3, UnitQuantity = 1 };

            var cart = new List<CartItem> { headphones, usb, mointor, laptop };

            var calc = new Calculator(new ShippingCalculator(), _productRepository, _discountRepository);

            double[] totalArray = calc.GetTotalAndShiping(cart, "APPLE5");

            var shipping = totalArray[1];
            var total = totalArray[0];

            System.Console.WriteLine(total);
            System.Console.WriteLine(shipping);

            total += shipping;

            Assert.AreEqual(1122.8, total);
        }

        [Test]
        public void WithDiscount_FREESHIPPING_CheckCalculation()
        {
            var headphones = new CartItem { ProductId = 2, UnitQuantity = 2 };
            var usb = new CartItem { ProductId = 1, UnitQuantity = 1 };
            var mointor = new CartItem { ProductId = 4, UnitQuantity = 1 };
            var laptop = new CartItem { ProductId = 3, UnitQuantity = 1 };

            var cart = new List<CartItem> { headphones, usb, mointor, laptop };

            var calc = new Calculator(new ShippingCalculator(), _productRepository, _discountRepository);

            double[] totalArray = calc.GetTotalAndShiping(cart, "FREESHIPPING");

            var shipping = totalArray[1];
            var total = totalArray[0];

            System.Console.WriteLine(total);
            System.Console.WriteLine(shipping);

            total += shipping;

            Assert.AreEqual(0, shipping);
        }

        [Test]
        public void WithDiscount_INVALID_CheckCalculation()
        {
            var headphones = new CartItem { ProductId = 2, UnitQuantity = 2 };
            var usb = new CartItem { ProductId = 1, UnitQuantity = 1 };
            var mointor = new CartItem { ProductId = 4, UnitQuantity = 1 };
            var laptop = new CartItem { ProductId = 3, UnitQuantity = 1 };

            var cart = new List<CartItem> { headphones, usb, mointor, laptop };

            var calc = new Calculator(new ShippingCalculator(), _productRepository, _discountRepository);

            double[] totalArray = calc.GetTotalAndShiping(cart, "INVALID");

            var shipping = totalArray[1];
            var total = totalArray[0];

            System.Console.WriteLine(total);
            System.Console.WriteLine(shipping);

            total += shipping;

            Assert.AreEqual(1124, total);
        }

        [Test]
        public void WithOneItem_CheckCalculation()
        {
            var carItem1 = new CartItem { ProductId = 1, UnitQuantity = 1 };
     
            var cart = new List<CartItem> { carItem1 };

            var calc = new Calculator(new ShippingCalculator(), _productRepository, _discountRepository);

            double[] totalArray = calc.GetTotalAndShiping(cart, "FREESHIPPING");

            var shipping = totalArray[1];
            var total = totalArray[0];

            System.Console.WriteLine(total);
            System.Console.WriteLine(shipping);

            total += shipping;

            Assert.AreEqual(4, total);
        }
    }
}