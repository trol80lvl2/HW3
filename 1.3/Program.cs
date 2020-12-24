using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Region, RegionSettings> keyValues;
            Console.WriteLine("'Dictionary with key' made by Roman Holub");
            Console.WriteLine("Enter element counts in dictionary. Then enter all elements step by step. \n" +
                "Enter data asked by program and everything will be OK\n" +
                "Enter -exit when program asks you to enter count of items in dictionary to exit");
            int n = 0;

            string console="";
            do
            { 
                Console.Write("Enter count of array elements->");
                console = Console.ReadLine();
                if (console.Trim().ToLower() == "-exit")
                    Process.GetCurrentProcess().Kill();
            }
            while (!int.TryParse(console, out n) && n! > 0);

            keyValues = new Dictionary<Region, RegionSettings>(n);

            int counter = 0;
            while (counter < n)
            {
                Region region = new Region();
                RegionSettings regionSettings = new RegionSettings();
                Console.Write($"\nEnter {++counter} Brand->");
                region.Brand = Console.ReadLine();
                Console.Write($"Enter {counter} Country->");
                region.Country = Console.ReadLine();
                Console.Write($"Enter {counter} Web-Site->");
                regionSettings.WebSite = Console.ReadLine();

                if (keyValues.TryAdd(region, regionSettings))
                    continue;
                else
                {
                    Console.WriteLine("The same record already exists");
                    counter--;
                }                  
            }
            Console.WriteLine("\n");
            foreach(var item in keyValues)
            {
                Console.WriteLine($"{item.Key.Brand} {item.Key.Country} {item.Value.WebSite}");
            }
        }
    }
}
