namespace App1.Models
{
    using System;

    public class PaymentProcessor
    {
        public void ChargeCreditCard(string creditCardNumber, string expiryDate)
        {
            if(string.IsNullOrEmpty(creditCardNumber)) throw new ArgumentException("Invalid Credit card number");
            if(string.IsNullOrEmpty(expiryDate)) throw new ArgumentException("Invalid Credit cExpiry Date");

            Console.WriteLine("Call To Credit Card API");
        }
    }
}