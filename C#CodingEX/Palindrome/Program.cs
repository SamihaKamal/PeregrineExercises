using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //String a = "Book";
            bool isPalin = true;
            //String a = "madam";
            String a = "step on no pets";

            Char[] initial = a.ToCharArray();

            for (int i = 0; i < initial.Length; i++)
            {
                int lastElement = (initial.Length - 1) - i;
                if (initial[i] != initial[lastElement])
                {
                    isPalin = false;
                    break;
                }
            }

            if (isPalin == false)
            {
                Console.WriteLine("is not a palindrome");
            }
            else
            {
                Console.WriteLine("is a palindrome");
            }

            Console.ReadLine();
            
        }
    }
}
