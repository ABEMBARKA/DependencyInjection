namespace App1.Models
{
    using System;
    using System.Collections.Generic;

    public class ProductStockRepository
    {
        public static Dictionary<Product, int> ProductStockDatabase=Seed();

        private static  Dictionary<Product,int> Seed()
        {
            var producStockDatabase = new Dictionary<Product, int>
            {
                {Product.Keyboard, 1}, {Product.Mic, 1}, {Product.Mouse, 1}, {Product.Speaker, 1}
            };

            return producStockDatabase;
        }

        public bool IsInStock(Product product)
        {
            Console.WriteLine("Call Get On Database");
            return ProductStockDatabase[product] >0;
        }

        public void ReduceStock(Product product)
        {
            Console.WriteLine("Call Update On Database");
            ProductStockDatabase[product]--;
        }
         public void AddStock(Product product)
        {
            Console.WriteLine("Call Update On Database");
            ProductStockDatabase[product]++;
        }

    }
}