using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circ = new Circle();
            Rectangle rec = new Rectangle();
            Triangle tri = new Triangle();
            Console.WriteLine("Do you want to calculate area or perimetre? 1 for area, 0 for perimetre");
            int ap = int.Parse(Console.ReadLine());
            if (ap == 1)
            {
                Console.WriteLine("Do you want to find the area of a Circle (0), Triangle (1) or Rectangle (2)? ");
                int shape = int.Parse(Console.ReadLine());
                if (shape == 0)
                {
                    Console.WriteLine("Enter the radius");
                    double radius = double.Parse(Console.ReadLine());
                    circ.radius = radius;
                    Console.WriteLine("The area is: " + circ.Area());
                }else if (shape == 1)
                {
                    Console.WriteLine("Enter side a, b and c respectively");
                    double sidea = double.Parse(Console.ReadLine());
                    double sideb = double.Parse(Console.ReadLine());
                    double sidec = double.Parse(Console.ReadLine());
                    tri.sidea = sidea;
                    tri.sideb = sideb;
                    tri.sidec = sidec;
                    if (tri.Area() == 0)
                    {
                        Console.WriteLine("That wasnt a triangle...");
                    }
                    else
                    {
                        Console.WriteLine("The area of a triangle is: " + tri.Area());
                    }
                }
                else if (shape == 2)
                {
                    Console.WriteLine("Enter height and width respectively");
                    double height = double.Parse(Console.ReadLine());
                    double length = double.Parse(Console.ReadLine());
                    rec.height = height;
                    rec.width = length;
                    Console.WriteLine("The area of the rectangle is " + rec.Area());
                }
                else
                {
                    Console.WriteLine("Thats not a shape.. please enter a correct one next time");
                }
            }else if(ap == 0)
            {
                Console.WriteLine("Do you want to find the perimetre of a Circle (0), Triangle (1) or Rectangle (2)? ");
                int shape = int.Parse(Console.ReadLine());
                if (shape == 0)
                {
                    Console.WriteLine("Enter the radius");
                    double radius = double.Parse(Console.ReadLine());
                    circ.radius = radius;
                    Console.WriteLine("The area is: " + circ.Perimetre());
                }
                else if (shape == 1)
                {
                    Console.WriteLine("Enter side a, b and c respectively");
                    double sidea = double.Parse(Console.ReadLine());
                    double sideb = double.Parse(Console.ReadLine());
                    double sidec = double.Parse(Console.ReadLine());
                    tri.sidea = sidea;
                    tri.sideb = sideb;
                    tri.sidec = sidec;
                    if (tri.Perimetre() == 0)
                    {
                        Console.WriteLine("That wasnt a triangle...");
                    }
                    else
                    {
                        Console.WriteLine("The area of a triangle is: " + tri.Perimetre());
                    }
                }
                else if (shape == 2)
                {
                    Console.WriteLine("Enter height and width respectively");
                    double height = double.Parse(Console.ReadLine());
                    double length = double.Parse(Console.ReadLine());
                    rec.height = height;
                    rec.width = length;
                    Console.WriteLine("The area of the rectangle is " + rec.Perimetre());
                }
                else
                {
                    Console.WriteLine("Thats not a shape.. please enter a correct one next time");
                }
            }
            else
            {
                Console.WriteLine("Please enter a real number next time");
            }

            Console.ReadLine();
            
        }
    }
}
