using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _1._2
{
    public class PlayerDistinct<T> : IEqualityComparer<T> where T : Player
    {
        public bool Equals(T x,T y)
        {
            return (x.Age == y.Age && x.Rank == y.Rank && x.FirstName == y.FirstName && x.LastName == y.LastName) ? true : false;
                
        }

        public int GetHashCode(T obj)
        {
            return obj.Age.GetHashCode()+obj.FirstName.GetHashCode()+obj.LastName.GetHashCode()+obj.Rank.GetHashCode();
        }
    }
}
