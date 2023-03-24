using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class NewPrice : TaxPrice
    {
        public float DecreasePrice()
        {
            price = price - 2500;
            return price;
        }

        public float DecreasePrice(int reqPrice, float discount)
        {
            price = price - (reqPrice * discount);
            return price;
        }

        public override void AdjustPrice()
        {
            if(price >= 7500 && price < 12000)
            {
                DecreasePrice();
                Console.WriteLine("New Price\t: Rp" + price);
                Console.WriteLine();
            }
            else if (price >= 12000 && price <= 17500)
            {
                DecreasePrice(3500, 0.8f);
                Console.WriteLine("New Price\t: Rp" + price);
                Console.WriteLine();
            }
            else
            {
                base.AdjustPrice();
            }
        }
    }
}
