using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEach__in
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 2, 4, 6, 8, 10 };
            foreach (int val in number)
            {
                Console.WriteLine(val);
            }

            Console.ReadLine();
        }
    }
}
