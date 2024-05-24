using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>() { 3, 1, 5, 7, 5, 9 };
            Tuple<int, int> result = null;
            int targetSum = 10;
            bool tag = false;

             for(int j=0; j < a.Count; j++)
                {
                    for (int i = 0; i < a.Count; i++)
                    {
                        if (a[j] + a[i] == targetSum)
                        {
                        result = new Tuple<int, int>(j, i);
                        }
                    }
                }

            if (result == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine("This is the tuple: {0},{1}", result.Item1, result.Item2);
            }
            
            Console.ReadLine();
        }
    }
}
