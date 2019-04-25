namespace App1.Models
{
    using System;

    public class OrderManager
    {
        public void Submit(Product product, string creditCardNumber, string expiryDate)
        {
            //Cheack product stock
            var productStockRepository= new ProductStockRepository();
            if(!productStockRepository.IsInStock(product)) throw new Exception($"{product.ToString()} not in stock");
            
            //Payment
            var paymentProcessor= new PaymentProcessor();
            paymentProcessor.ChargeCreditCard(creditCardNumber,expiryDate);

            //Ship product
        }
    }
}