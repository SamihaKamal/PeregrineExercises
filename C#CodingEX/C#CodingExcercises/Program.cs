using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_CodingExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Example array
            //int[] array = { 1, 2, 1, 1, 0, 3, 1, 0, 0, 2, 4, 1, 0, 0, 0, 0, 2, 1, 0, 3, 1, 0, 0, 0, 6, 1, 3, 0, 0, 0 };
            //Array with no zeroes
            //int[] array = { 2, 3, 57, 83, 1, 4, 6, 8, 1, 3, 6, 6, 4 };
            //Array with twice instance of the same amount of zeroes
            int[] array = { 0, 0, 0, 2, 4, 1, 2, 0, 0, 1, 3, 0, 0, 0, 23 };
           
            int saved_count = 0;
            int count = 0;
            int length = array.Length;

            for (int i = 0; i < length; i++)
            {

               if (array[i] == 0)
                {
                    count = count + 1;
                }
                if ((array[i] != 0) && (i != 0))
                {
                    if (array[i-1] == 0)
                    {
                        if (count > saved_count)
                        {       
                            saved_count = count;
                            count = 0;
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                }
            }

            
            Console.WriteLine("Longest number of zeroes is: {0}", saved_count);
            Console.ReadLine();
        }
    }
}
