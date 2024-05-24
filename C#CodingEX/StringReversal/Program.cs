using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReversal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String a = "Hello, world";
            char[] b = a.ToCharArray();

            for (int i = b.Length - 1; i>-1; i--)
            {
                Console.WriteLine(b[i]);
            }

            Console.ReadLine();
        }
    }
}
