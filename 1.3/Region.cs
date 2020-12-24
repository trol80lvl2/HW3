using System;
using System.Collections.Generic;
using System.Text;

namespace _1._3
{
    public class Region : IRegion
    {
        public string Brand { get; set; }

        public string Country { get; set; }

        public override int GetHashCode()
        {
            return (Brand.GetHashCode()*3) ^ (Country.GetHashCode()*2);
        }

        public override bool Equals(object obj)
        {
            var item = obj as Region;
            return obj.GetHashCode() == GetHashCode();
        }
    }
}
