using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool found = false;
            Console.WriteLine("Enter a number: ");
            String a = Console.ReadLine();

            int number = int.Parse(a);

            while (found == false)
            {
                int isNumPrime = isPrime(number + 1);
                if (isNumPrime == 1)
                {
                    number = number + 1;
                }
                else
                {
                    found = true;
                }
            }

            Console.WriteLine("Next prime number is: {0} ", (number + 1));
            Console.ReadLine();
        }

        public static int isPrime(int a)
        {
            int isPrime = 0;

            if (a == 1)
            {
                isPrime = 1;
            }else if(a> 1)
            {
                for(int i=2; i<a; i++)
                {
                    if((a%i) == 0)
                    {
                        isPrime = 1;
                        break;
                    }
                }
            }

            return isPrime;
        }

    }
}
