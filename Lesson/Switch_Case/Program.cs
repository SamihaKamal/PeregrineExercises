using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Case
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            Console.Write("Enter a positive number: ");
            x = Convert.ToInt16(Console.ReadLine());

            if (x > 0)
            {
                switch(x)
                {
                    case 0:
                        Console.WriteLine("The value of x is 0");
                        break;
                    case 1:
                        Console.WriteLine("The value of x is 1");
                        break;
                    case 2:
                        Console.WriteLine("The value of x is 2");
                        break;
                    case 3:
                        Console.WriteLine("The value of x is 3");
                        break;
                    case 4:
                        Console.WriteLine("The value of x is 4");
                        break;
                    case 5:
                        Console.WriteLine("The value of x is 5");
                        break;
                    default:
                        Console.WriteLine("The value of x is greater than 5");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Negative numbers not allowed!");
            }
            Console.ReadLine();

            //Breaks would be if a piece of code was executed and instead of continuing on in the loop or selection, u want it to end therefore u break out of the loop
            //Continues starts a new interation of the selection/interation statement
            //Goto gives control to a statement that is marked by a label, you can use it to get out of a nested loop.
        }
    }
}
