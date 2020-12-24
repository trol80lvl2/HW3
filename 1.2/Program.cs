using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>()
            {
                new Player{Age = 29, FirstName = "Ivan", LastName = "Ivanenko", Rank = PlayerRank.Captain},
                new Player{Age = 19, FirstName = "Peter", LastName = "Petrenko", Rank = PlayerRank.Private},
                new Player{Age = 59, FirstName = "Ivan", LastName = "Ivanov", Rank = PlayerRank.General},
                new Player{Age = 34, FirstName = "Alex", LastName = "Zeshko", Rank = PlayerRank.Colonel},
                new Player{Age = 29, FirstName = "Ivan", LastName = "Ivanenko", Rank = PlayerRank.Captain},
                new Player{Age = 19, FirstName = "Peter", LastName = "Petrenko", Rank = PlayerRank.Private},
                new Player{Age = 34, FirstName = "Vasiliy", LastName = "Sokol", Rank = PlayerRank.Major},
                new Player{Age = 31, FirstName = "Alex", LastName = "Alexeenko", Rank = PlayerRank.Major}
            };

            FIOSorter<Player> fioSorter = new FIOSorter<Player>();
            AgeSorter<Player> ageSorter = new AgeSorter<Player>();
            RankSorter<Player> rankSorter = new RankSorter<Player>();
            PlayerDistinct<Player> playerDistinct = new PlayerDistinct<Player>();


            Console.WriteLine("'Three sorters and one comparer' made by Roman Holub\n");
            //MUST BE RESORTED, BRO. 
            //OK, I'LL REWRITE
            //DON'T FORGER. 
            //OK

            players = players.Distinct(playerDistinct).ToList();


            players.Sort(fioSorter);
            foreach (var item in players)
            {
                Console.WriteLine($"{item.Age}|{item.FirstName} {item.LastName}|{item.Rank}");
            }
            players.Sort(ageSorter);
            Console.WriteLine("-----------------------------------");
            foreach (var item in players)
            {
                Console.WriteLine($"{item.Age}|{item.FirstName} {item.LastName}|{item.Rank}");
            }
            players.Sort(rankSorter);
            Console.WriteLine("-----------------------------------");
            foreach (var item in players)
            {
                Console.WriteLine($"{item.Age}|{item.FirstName} {item.LastName}|{item.Rank}");
            }

        }
    }
}
