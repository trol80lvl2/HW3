using System;
using System.Collections.Generic;
using System.Text;

namespace _1._2
{
    public class Player : IPlayer
    {
        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PlayerRank Rank { get; set;  }
    }
}
