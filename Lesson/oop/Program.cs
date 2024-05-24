using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            int x = 3;
            int y = 5;
            int sum = 0;
            sum = calc.Add(x, y);
            Console.WriteLine("Sum of {0} and {1} = {2}", x, y, sum);
            Console.WriteLine("Subtraction of {0} and {1} = {2}", x, y, calc.Subtract(x,y));
            Console.WriteLine("Multiplication of {0} and {1} = {2}", x, y, calc.Multiply(x,y));
            Console.WriteLine("Division of {0} and {1} = {2}", x, y, calc.Divide(x,y));
            Console.ReadLine();
        }
    }
}
