using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _1._2
{
    public class FIOSorter<T> : IComparer<T> where T : Player
    {
        public int Compare(T x, T y)
        {
            var ret = string.CompareOrdinal(x.LastName, y.LastName);
            if (ret != 0) return ret;
            return string.CompareOrdinal(x.FirstName, y.FirstName);
        }
    }
}
