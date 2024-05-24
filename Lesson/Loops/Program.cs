using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            double count = 0;

            while(count != 10)
            {
                sum = sum + Math.Pow(count, 2.0);
                Console.WriteLine("count: {0}    sum: {1}", count, sum);
                count++;
            }

            /*do
            {
                sum = sum + Math.Pow(count, 2.0);
                Console.WriteLine("count: {0}    sum: {1}", count, sum);
                count++;
            } while (count != 10);*/

            for (int i = 1; i < 100; i = i + 2)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
