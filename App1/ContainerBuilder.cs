namespace App1
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public class ContainerBuilder
    {

        public IServiceProvider Build()
        {
            var container = new ServiceCollection();
            container.AddSingleton<IOrdenManager, OrderManager>();
            container.AddSingleton<IPaymentProcessor, PaymentProcessor>();
            container.AddSingleton<IProductStockRepository, ProductStockRepository>();
            container.AddSingleton<IShippingProcessor, ShippingProcessor>();
            return container.BuildServiceProvider();
        }
    }
}