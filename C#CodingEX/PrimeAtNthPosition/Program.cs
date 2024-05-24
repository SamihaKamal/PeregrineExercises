using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeAtNthPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            Console.WriteLine("Enter a number: ");
            String a = Console.ReadLine();

            int position = int.Parse(a);

            Console.WriteLine("Prime number at position {0} is {1}.", position, sequence[position]);
            Console.ReadLine();

        }
    }
}
