using System;
using Xunit;

namespace App1.Test
{
    using Models;
    using Moq;

    public class OrderManagerTest
    {
        [Fact]
        public void Test1()
        {

            var productStockRepositoryMoq = new Mock<IProductStockRepository>();
            productStockRepositoryMoq.Setup(m => m.IsInStock(It.IsAny<Product>())).Returns(false);
            var paymentProcessorMoq = new Mock<IPaymentProcessor>();
            var shippingProcessor = new Mock<IShippingProcessor>();

            var orderManager = new OrderManager(shippingProcessor.Object,productStockRepositoryMoq.Object,paymentProcessorMoq.Object);
            Assert.ThrowsAny<Exception>(() => orderManager.Submit(Product.Keyboard, "Bembarka abdekhalel", "05/20"));
        }
    }
}
