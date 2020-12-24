using System;
using System.Collections.Generic;
using System.Text;

namespace _1._2
{
    public enum PlayerRank
    {
        Private = 2, Lieutenant = 21, Captain = 25, Major = 29, Colonel = 33, General = 39
    }

    interface IPlayer
    {
        public int Age { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public PlayerRank Rank { get; }
    }
}
