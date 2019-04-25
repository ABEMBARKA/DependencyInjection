namespace App1
{
    using System;
    using Models;

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
            var shippingProcessor=new ShippingProcessor();
            shippingProcessor.MailProduct(product);
        }
    }
}