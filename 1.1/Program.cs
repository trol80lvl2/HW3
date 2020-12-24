using System;
using System.Linq;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("'Array statistic' made by Roman Holub");
            Console.WriteLine("Program made to give you statistics about your array. To enter array use ',' as separator between array elements.\nExample of right input:" +
                "'10, 20, 30, 54', '10, 20       , -30,,,'");
            bool isBadInput = true;
            while (isBadInput)
            {
                Console.Write("Enter your array->");
                var str = Console.ReadLine();
                if (str.Replace(" ", "").Length == 0)
                {
                    Console.WriteLine("Empty string. Please reread rules.");
                    continue;
                }
                    
                var splitArr = str.Split(",", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    int[] intsArr = splitArr.Select(int.Parse).ToArray();
                    int[] sortedUniqueArr = intsArr.Distinct().OrderBy(x=>x).ToArray();
                    int minElement = intsArr.Min();
                    int maxElement = intsArr.Max();
                    int sum = intsArr.Sum();
                    var average = Math.Round(intsArr.Average(),2);
                    double disperse = 0;
                    foreach(var item in intsArr)
                    {
                        disperse += (item - average) * (item - average);
                    }
                    disperse /= intsArr.Length;
                    Console.WriteLine($"Max element: {maxElement}\nMin element: {minElement}\nSum: {sum}\nAverage: {average}\nDisperse: {Math.Round(disperse,2)}");
                    Console.Write("Sorted array with unique values: [ ");
                    foreach(var item in sortedUniqueArr)
                    {
                        Console.Write(item+" ");
                    }
                    Console.Write("]\n");
                    isBadInput = false;

                }
                catch
                {
                    Console.WriteLine("Please, use correct input");
                    continue;
                }

            }

        }
    }
}
