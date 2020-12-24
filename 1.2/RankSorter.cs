using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;

namespace _1._2
{
    public class RankSorter<T> : IComparer<T> where T:Player
    {
        public int Compare(T x, T y)
        {
            if (x.Rank > y.Rank)
                return 1;
            else if (x.Rank < y.Rank)
                return -1;
            else
                return 0;
        }
    }
}
