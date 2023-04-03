using Connection.Contexts;
using Connection.Controllers;
using Connection.Models;
using Connection.Repositories;
using Connection.Views;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;


namespace Connection;

public class Program
{
    public static void Main()
    {
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("======= Database Connectivity =======");
            Console.WriteLine("1. Manage Table Region");
            Console.WriteLine("2. Manage Table Country");
            Console.WriteLine("3. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Region();
                    break;
                case 2:
                    Country();
                    break;
                case 3:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        }
        while (check);
    }

    public static void Region()
    {
        RegionController regionController = new RegionController(new RegionRepository(), new VRegion());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Region========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    regionController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Input Id: ");
                    var id = Convert.ToInt16(Console.ReadLine());
                    regionController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=======Insert Region========");
                    Console.Write("Input Name: ");
                    var nameInsert = Console.ReadLine();
                    regionController.Insert(new Region
                    {
                        Name = nameInsert
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=======Update Region========");
                    Console.Write("Input Id: ");
                    var idUpdate = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Input Name: ");
                    var nameUpdate = Console.ReadLine();
                    regionController.Update(new Region
                    {
                        Name = nameUpdate,
                        Id = idUpdate
                    });
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("=======Delete Region========");
                    Console.Write("Input Id: ");
                    var idDelete = Convert.ToInt16(Console.ReadLine());
                    regionController.Delete(idDelete);
                    Console.ReadKey();
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

    public static void Country()
    {
        CountryController countryController = new CountryController(new CountryRepository(), new VCountry());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Country========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    countryController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Input Id: ");
                    var id = Console.ReadLine();
                    countryController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=======Insert Country========");
                    Console.Write("Input Id: ");
                    var idInsert = Console.ReadLine();
                    Console.Write("Input Name: ");
                    var nameInsert = Console.ReadLine();
                    Console.Write("Input Region: ");
                    var regionInsert = Convert.ToInt16(Console.ReadLine());
                    countryController.Insert(new Country
                    {
                        Id = idInsert,
                        Name = nameInsert,
                        Region = regionInsert
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=======Update Country========");
                    Console.Write("Input Id: ");
                    var idUpdate = Console.ReadLine();
                    Console.Write("Input Name: ");
                    var nameUpdate = Console.ReadLine();
                    Console.Write("Input Region: ");
                    var regionUpdate = Convert.ToInt16(Console.ReadLine());
                    countryController.Update(new Country
                    {
                        Id = idUpdate,
                        Name = nameUpdate,
                        Region = regionUpdate
                    });
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("=======Delete Country========");
                    Console.Write("Input Id: ");
                    var idDelete = Console.ReadLine();
                    countryController.Delete(idDelete);
                    Console.ReadKey();
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }
}