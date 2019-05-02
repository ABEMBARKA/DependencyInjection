using System;

namespace App1
{
    using System.ComponentModel.Design;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    class Program
    {
        public static readonly IServiceProvider Container=new ContainerBuilder().Build();
        static void Main(string[] args)
        {
            var product = string.Empty;
            var orderManager = Container.GetService<IOrdenManager>();
            while (product != "exit")
            {
                Console.Write(@"Enter a Product:
                                Keyboard=0,
                                Mouse=1,
                                Mic=2,
                                Speaker=3
                                ");
                product = Console.ReadLine();
                try
                {
                    if (Enum.TryParse(product, out Product productEnum))
                    {
                        Console.WriteLine("Please enter a valid payment method: xxxxxxxxxxx;MMYY");
                        var paymentMethod = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentMethod) || paymentMethod.Split(";").Length != 2)
                        {
                            throw new Exception("Invalid payment method");
                        }
                        orderManager.Submit(productEnum, paymentMethod.Split(";")[0], paymentMethod.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} has been shipped");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Product");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(Environment.NewLine);

            }
        }
    }
}
