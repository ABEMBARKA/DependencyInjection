namespace App1
{
    using System;
    using Models;

    public interface IOrdenManager
    {
         void Submit(Product product, string creditCardNumber, string expiryDate);
    }
    public class OrderManager:IOrdenManager
    {
        private readonly IShippingProcessor _shippingProcessor;
        private readonly IProductStockRepository _productStockRepository;
        private IPaymentProcessor _paymentProcessor;

        public OrderManager(IShippingProcessor shippingProcessor, IProductStockRepository productStockRepository, IPaymentProcessor paymentProcessor)
        {
            _shippingProcessor = shippingProcessor;
            _productStockRepository = productStockRepository;
            _paymentProcessor = paymentProcessor;
        }

        public void Submit(Product product, string creditCardNumber, string expiryDate)
        {
            //Cheack product stock
            if(!_productStockRepository.IsInStock(product)) throw new Exception($"{product.ToString()} not in stock");
            
            //Payment
            _paymentProcessor.ChargeCreditCard(creditCardNumber,expiryDate);

            //Ship product
            _shippingProcessor.MailProduct(product);
        }
    }
}