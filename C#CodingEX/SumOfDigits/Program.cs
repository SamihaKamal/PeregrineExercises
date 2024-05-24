using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int a = 12;
            int a = 231;
            int sum = 0;

            string initial = a.ToString();
            Char[] arrayInitial = initial.ToCharArray();

            for (int i = 0; i < arrayInitial.Length; i ++)
            {
                sum = sum + int.Parse(arrayInitial[i].ToString());
            }

            Console.WriteLine("Sum is: {0}", sum);
            Console.ReadLine();

        }
    }
}
