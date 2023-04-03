using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Views;
public class VRegion
{
    public void GetAll(List<Region> regions)
    {
        foreach(var region in regions)
        {
            Console.WriteLine("Id: " + region.Id);
            Console.WriteLine("Name: " + region.Name);
            Console.WriteLine();
        }
    }

    public void GetById(Region region)
    {
        Console.WriteLine("Id: " + region.Id);
        Console.WriteLine("Name: " + region.Name);
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
