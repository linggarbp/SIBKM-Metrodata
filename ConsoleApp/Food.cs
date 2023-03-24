using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    abstract class Food
    {
        public string category { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string type { get; set; }

        public abstract void AdjustPrice();

        public void FoodDesc()
        {
            Console.WriteLine("Category\t: " + category);
            Console.WriteLine("Name\t\t: " + name);
            Console.WriteLine("Price\t\t: Rp" + price);
            Console.WriteLine("Type\t\t: " + type);
        }
    }

}
