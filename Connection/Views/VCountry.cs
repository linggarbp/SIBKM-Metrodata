using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Views
{
    public class VCountry
    {
        public void GetAll(List<Country> countries)
        {
            foreach (var country in countries)
            {
                Console.WriteLine("Id: " + country.Id);
                Console.WriteLine("Name: " + country.Name);
                Console.WriteLine("Region: " + country.Region);
                Console.WriteLine();
            }
        }

        public void GetById(Country country)
        {
            Console.WriteLine("Id: " + country.Id);
            Console.WriteLine("Name: " + country.Name);
            Console.WriteLine("Region: " + country.Region);
        }

        public void Success(string message)
        {
            Console.WriteLine($"Data has been {message}");
        }

        public void Failure(string message)
        {
            Console.WriteLine($"Data has not been {message}");
        }

        public void DataNotFound()
        {
            Console.WriteLine("Data not Found!");
        }
    }
}
