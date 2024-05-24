﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsOnScreen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfStars = 0;
            int amountOfSpaces = 0;
            for (int i = 1; i < 6; i++)
            {
                amountOfStars = i + (i - 1);
                amountOfSpaces = 5 - i;
                //Print spaces first to center everything
                for (int k = 0; k < amountOfSpaces; k++)
                {
                    Console.Write(" ");
                }
                //Print stars in a row
                for (int j = 0; j < amountOfStars; j++)
                {
                    Console.Write("*");
                }
                //The print this to get to a new line
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
