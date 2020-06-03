﻿using Assignment4ThanosKatrakis.Entities;
using Assignment4ThanosKatrakis.Enumerations;
using Assignment4ThanosKatrakis.Strategies.PaymentStrategy;
using Assignment4ThanosKatrakis.Strategies.ProductVariationStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4ThanosKatrakis
{
    class EshopContext
    {
        private IPaymentMethodStrategy paymentMethod;
        private IEnumerable<VariationStrategy> variations;


        public EshopContext(IEnumerable<VariationStrategy> variations)
        {
            this.variations = variations;
        }
        public void SetVariationStrategy(IEnumerable<VariationStrategy> variations)
        {
            this.variations = variations;
        }

        public void SelectPaymentMethod(PaymentMethods p)
        {
            switch (p)
            {
                case PaymentMethods.DebitCard: paymentMethod = new CreditCard(); break;
                case PaymentMethods.BankTransfer: paymentMethod = new BankTransfer(); break;
                case PaymentMethods.Cash: paymentMethod = new Cash(); break;
                default: paymentMethod = new Cash(); break;
            }
        }

        public void TotalCostTShirt(Shirt shirt)
        {
            foreach (var variation in variations)
            {
                variation.Cost(shirt);
                Console.WriteLine($"TShirt cost after applying {variation.GetType().Name} is: {shirt.Price}");
            }
            Console.WriteLine("Total price : {0}", shirt.Price);
            paymentMethod.Pay(shirt.Price);
        }
    }
}
