using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _1._2
{
    public class AgeSorter<T> : IComparer<T> where T : Player
    {
        public int Compare(T x, T y)
        {
            if (x.Age > y.Age)
                return 1;
            else if (x.Age < y.Age)
                return -1;
            else
                return 0;
        }
    }
}
