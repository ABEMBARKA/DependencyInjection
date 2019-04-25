namespace App1.Models
{
    using System;

    public class ShippingProcessor
    {
        public void MailProduct(Product product)
        {
            var productStockRepository = new ProductStockRepository();
            productStockRepository.ReduceStock(product);
            Console.WriteLine("Call To Shipping API");
        }
    }
}