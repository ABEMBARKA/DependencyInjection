using System;
using Xunit;

namespace App1.Test
{
    public class OrderManagerTest
    {
        [Fact]
        public void Test1()
        {
            var orderManager = new OrderManager();
            orderManager.Submit(Product.Keyboard, "Bembarka abdekhalel", "05/20");
            Assert.ThrowsAny<Exception>(()=>orderManager.Submit(Product.Keyboard, "Bembarka abdekhalel", "05/20"));
        }
    }
}
