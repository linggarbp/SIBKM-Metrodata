using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class TaxPrice : Food
    {
        public float IncreasePrice()
        {
            price = price + 2500;
            return price;
        }

        public float IncreasePrice(int reqPrice, float tax)
        {
            price = price + (reqPrice * tax);
            return price;
        }

        public override void AdjustPrice()
        {
            if (price <= 5000)
            {
                IncreasePrice();
            }
            else
            {
                IncreasePrice(3500, 0.8f);
            }
            Console.WriteLine("New Price\t: Rp" + price);
            Console.WriteLine();
        }
    }
}

