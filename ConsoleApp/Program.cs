using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("====== Food List ======\n");

        Food food1 = new NewPrice
        {
            category = "Protein",
            name = "Steak",
            price = 10000,
            type = "Main Course"
        };
        food1.FoodDesc();
        food1.AdjustPrice();

        Food food2 = new NewPrice
        {
            category = "Fruits",
            name = "Salad",
            price = 6500,
            type = "Appetizer"
        };
        food2.FoodDesc();
        food2.AdjustPrice();

        Food food3 = new NewPrice
        {
            category = "Grains",
            name = "Fried Rice",
            price = 13000,
            type = "Main Course"
        };
        food3.FoodDesc();
        food3.AdjustPrice();

        Food food4 = new NewPrice
        {
            category = "Vegetables",
            name = "Roasted Potato",
            price = 2500,
            type = "Appetizer"
        };
        food4.FoodDesc();
        food4.AdjustPrice();

        Food food5 = new NewPrice
        {
            category = "Processed Milk",
            name = "Yogurt",
            price = 20000,
            type = "Desert"
        };
        food5.FoodDesc();
        food5.AdjustPrice();
    }
}