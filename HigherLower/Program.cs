using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int selectedNumber = random.Next(0, 99);

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Please enter a number: ");
                int guess = int.Parse(Console.ReadLine());

                if (guess > selectedNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if(guess < selectedNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You got the number! It was: {0}", guess);
                    Console.ReadLine();
                    return;
                }

            }
            Console.WriteLine("You didnt get the number! It was {0}", selectedNumber);
            Console.ReadLine();
        }
    }
}
