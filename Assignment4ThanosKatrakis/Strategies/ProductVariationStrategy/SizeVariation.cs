﻿using Assignment4ThanosKatrakis.Entities;
using Assignment4ThanosKatrakis.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4ThanosKatrakis.Strategies.ProductVariationStrategy
{
    class SizeVariation : VariationStrategy
    {
        public void Cost(Shirt shirt)
        {
            switch (shirt.Size)
            {
                case Size.XS: shirt.Price += 9.5m; break;
                case Size.S: shirt.Price += 8.3m; break;
                case Size.M: shirt.Price += 2.8m; break;
                case Size.L: shirt.Price += 6.9m; break;
                case Size.XL: shirt.Price += 5.6m; break;
                case Size.XXL: shirt.Price += 4.6m; break;
                default: break;
            }
        }
    }
}
