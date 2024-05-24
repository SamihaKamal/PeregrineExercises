using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
               String[] a = { "parts", "traps", "arts", "rats", "starts", "tarts", "rat", "art", "tar", "tars", "stars", "stray" };

                for (int i = 0; i < a.Length; i++)
                {

                    if (a[i].Length == 4)
                    {

                        if ((a[i].Contains('s')) && (a[i].Contains('r')) && (a[i].Contains('a')) && (a[i].Contains('t')))
                        {

                            Console.WriteLine(a[i]);

                        }
                    }
                }

                Console.ReadLine();

            
        }
    }
}
