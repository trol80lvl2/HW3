using System;
using System.Collections.Generic;

namespace _1._4
{
    class Program
    {
        static int BracketCheck(string s)
        {
            string t = "[{(<]})>";
            Stack<BracketModel> st = new Stack<BracketModel>();

            for (int i = 0; i < s.Length; i++)
            {
                int f = t.IndexOf(s[i]);

                if (f >= 0 && f <= 3)
                    st.Push(new BracketModel { Bracket = s[i], Pos = i });

                if (f > 3)
                {
                    try
                    {
                        if (st.Pop().Bracket != t[f - 4])
                            return st.Pop().Pos;
                    }
                    catch
                    {
                        return i;
                    }
                }
            }

            if (st.Count != 0)
                return st.Pop().Pos;

            return -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Bracket checker. Made by Roman Holub");
            Console.WriteLine("Rules: enter string with brackets from this list:(),[],{},<>\nIf all brackets are odd, you'll have 'Success' message, otherwise you'll get position of invalid brackets using");
            while (true)
            {
                Console.Write("Please, enter checked string->");
                var str = Console.ReadLine();
                int outP;
                Console.WriteLine(BracketCheck(str) == -1 ? "Success" : BracketCheck(str).ToString());
            }

        }

    }
}
