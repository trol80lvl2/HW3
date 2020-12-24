using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2
{
    class Program
    {
        static List<Tags> GetTags()
        {
            List<Tags> tags = new List<Tags>();
            string path = Directory.GetCurrentDirectory() + "//Tags.csv";
            var lines = File.ReadAllLines(path).Skip(1).Select(x => x.Split(";")).ToList();
            foreach (var line in lines)
            {
                tags.Add(new Tags { ProductId = line?[0], Value = line?[1]});
            }

            return tags;
        }
        static List<Inventory> GetInventory()
        {
            List<Inventory> inventory = new List<Inventory>();
            string path = Directory.GetCurrentDirectory() + "//Inventory.csv";
            var lines = File.ReadAllLines(path).Skip(1).Select(x => x.Split(";")).ToList();
            foreach (var line in lines)
            {
                inventory.Add(new Inventory { ProductId = line?[0], Location = line?[1], Balance = Convert.ToInt32(line?[2])});
            }

            return inventory;
        }
        static List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();
            string path = Directory.GetCurrentDirectory()+"//Products.csv";
            var lines = File.ReadAllLines(path).Skip(1).Select(x=>x.Split(";")).ToList();
            foreach(var line in lines)
            {
                products.Add(new Products { Id = line?[0], Brand = line?[1], Model = line?[2], Price = Convert.ToDecimal(line?[3]) });  
            }

            return products;
        }
        static int Main(string[] args)
        {
            try
            {
                List<Tags> tags = GetTags();
                List<Inventory> inventory = GetInventory();
                List<Products> products = GetProducts();
                bool isGoingApp = true;
                while (isGoingApp)
                {
                    Console.Clear();
                    Console.WriteLine("'ERP Report Bot' made by Roman Holub");
                    Console.WriteLine("Short rules:\n1)Move through the menu by numbers on your NumPad or under F keys.\n2)Enter correct data, otherwise you'll have warning\n");
                    Console.WriteLine("1. Exit\n2. Products\n3. Leftovers");
                    var key = Console.ReadKey().Key;
                    Console.Clear();
                    switch (key)
                    {
                        //Exit
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            isGoingApp = false;
                            break;
                        //Products
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            bool isGoing2 = true;
                            while (isGoing2)
                            {
                                Console.Clear();
                                Console.WriteLine("1. Go to main menu\n2. Search product\n3. Products list ASC\n4. Product list DESC");
                                var key2 = Console.ReadKey().Key;
                                switch (key2)
                                {
                                    //Main menu
                                    case ConsoleKey.D1:
                                    case ConsoleKey.NumPad1:
                                        isGoing2 = false;
                                        break;
                                    //Search product
                                    case ConsoleKey.D2:
                                    case ConsoleKey.NumPad2:
                                        Console.Clear();
                                        Console.Write("Enter keyword->");
                                        string keyWord = Console.ReadLine().ToLower();
                                        var searchById = products.Distinct().Where(x => x.Id.ToLower() == keyWord).ToList();
                                        var searchByModelBrand = products.Distinct().Where(x => x.Brand.ToLower().Contains(keyWord) || x.Model.ToLower().Contains(keyWord)).ToList();
                                        var searchByTags = products.Distinct().Join(tags,
                                            x => x.Id,
                                            y => y.ProductId,
                                            (x, y) => new { x, y }
                                            ).Where(o => o.y.Value.ToLower().Contains(keyWord)).Select(x => x.x).ToList();
                                        var generalCollection = searchByModelBrand.Union(searchById).Union(searchByTags);
                                        Console.WriteLine($"|{"Id",-10}|{"Brand",-20}|{"Model",-20}|{"Price",-10}|");
                                        Console.WriteLine("------------------------------------------------------------------");
                                        foreach (var item in generalCollection)
                                        {
                                            Console.WriteLine($"|{item.Id,-10}|{item.Brand,-20}|{item.Model,-20}|{item.Price,-10}|");
                                        }
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();


                                        break;
                                    //Product list ASC
                                    case ConsoleKey.D3:
                                    case ConsoleKey.NumPad3:
                                        Console.Clear();
                                        Console.WriteLine($"|{"Id",-10}|{"Brand",-20}|{"Model",-20}|{"Price",-10}|{"Tags",-40}|");
                                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                                        var ASCSort = products.GroupJoin(tags,
                                            x => x.Id,
                                            y => y.ProductId,
                                            (x, y) => new { x, y }
                                            ).OrderBy(o => o.x.Price).ToList();
                                        foreach (var item in ASCSort)
                                        {
                                            string tagsA = "";
                                            foreach (var tag in item.y)
                                            {
                                                tagsA += tag.Value + " ";
                                            }
                                            Console.WriteLine($"|{item.x.Id,-10}|{item.x.Brand,-20}|{item.x.Model,-20}|{item.x.Price,-10}|{tagsA,-40}|");
                                        }
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    //Product list DESC
                                    case ConsoleKey.D4:
                                    case ConsoleKey.NumPad4:
                                        Console.Clear();
                                        Console.WriteLine($"|{"Id",-10}|{"Brand",-20}|{"Model",-20}|{"Price",-10}|{"Tags",-40}|");
                                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                                        var DESCSort = products.GroupJoin(tags,
                                            x => x.Id,
                                            y => y.ProductId,
                                            (x, y) => new { x, y }
                                            ).OrderByDescending(o => o.x.Price).ToList();
                                        foreach (var item in DESCSort)
                                        {
                                            string tagsA = "";
                                            foreach (var tag in item.y)
                                            {
                                                tagsA += tag.Value + " ";
                                            }
                                            Console.WriteLine($"|{item.x.Id,-10}|{item.x.Brand,-20}|{item.x.Model,-20}|{item.x.Price,-10}|{tagsA,-40}|");
                                        }
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            break;
                        //Leftovers
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            bool isGoing3 = true;
                            while (isGoing3)
                            {
                                Console.Clear();
                                Console.WriteLine("1. Go to main menu\n2. Missing products\n3. Leftovers ASC\n4. Leftovers DESC");
                                var key2 = Console.ReadKey().Key;
                                switch (key2)
                                {
                                    //Main menu
                                    case ConsoleKey.D1:
                                    case ConsoleKey.NumPad1:
                                        isGoing3 = false;
                                        break;
                                    //Missing products
                                    case ConsoleKey.D2:
                                    case ConsoleKey.NumPad2:
                                        Console.Clear();
                                        var prod = (from p in products
                                                    join i in inventory on p.Id equals i.ProductId into inv
                                                    from i in inv.DefaultIfEmpty()
                                                    where i?.ProductId == null || i?.Balance == 0
                                                    select p).OrderBy(k => k.Id).ToList();
                                        Console.WriteLine($"|{"Id",-10}|{"Brand",-20}|{"Model",-20}|{"Price",-10}|");
                                        Console.WriteLine("-----------------------------------------------------------------");
                                        foreach (var item in prod)
                                        {
                                            Console.WriteLine($"|{item.Id,-10}|{item.Brand,-20}|{item.Model,-20}|{item.Price,-10}|");
                                        }
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    //Leftovers ASC
                                    case ConsoleKey.D3:
                                    case ConsoleKey.NumPad3:
                                        Console.Clear();
                                        var productsLeftAsc = products.GroupJoin(
                                                inventory,
                                                p => p.Id,
                                                t => t.ProductId,
                                                (p, t) => new
                                                {
                                                    Id = p.Id,
                                                    Brand = p.Brand,
                                                    Model = p.Model,
                                                    Price = p.Price,
                                                    Left = t.Sum(x => x.Balance)
                                                }
                                            ).OrderBy(x => x.Left).ToList();
                                        Console.WriteLine($"|{"Id",-10}|{"Brand",-20}|{"Model",-20}|{"Price",-10}|{"Left",-10}|");
                                        Console.WriteLine("----------------------------------------------------------------------------");
                                        foreach (var item in productsLeftAsc)
                                        {
                                            Console.WriteLine($"|{item.Id,-10}|{item.Brand,-20}|{item.Model,-20}|{item.Price,-10}|{item.Left,-10}|");
                                        }
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    //Leftovers DESC
                                    case ConsoleKey.D4:
                                    case ConsoleKey.NumPad4:
                                        Console.Clear();
                                        var productsLeftDesc = products.GroupJoin(
                                                inventory,
                                                p => p.Id,
                                                t => t.ProductId,
                                                (p, t) => new
                                                {
                                                    Id = p.Id,
                                                    Brand = p.Brand,
                                                    Model = p.Model,
                                                    Price = p.Price,
                                                    Left = t.Sum(x => x.Balance)
                                                }
                                            ).OrderByDescending(x => x.Left).ToList();
                                        Console.WriteLine($"|{"Id",-10}|{"Brand",-20}|{"Model",-20}|{"Price",-10}|{"Left",-10}|");
                                        Console.WriteLine("----------------------------------------------------------------------------");
                                        foreach (var item in productsLeftDesc)
                                        {
                                            Console.WriteLine($"|{item.Id,-10}|{item.Brand,-20}|{item.Model,-20}|{item.Price,-10}|{item.Left,-10}|");
                                        }
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Try to select correct menu option. Press any key to continue...");
                            Console.ReadKey();
                            break;
                    }
                }
                return 0;
            }
            catch
            {
                Console.WriteLine("Something went wrong. Try to check your files.");
                Console.ReadKey();
                return -1;
            }
        }
    }
}
