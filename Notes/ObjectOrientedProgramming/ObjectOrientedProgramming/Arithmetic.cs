using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming
{
    //Arithmetic is inheritting from multiply.
    internal class Arithmetic : Multiply, ISubtract 
    {
        //property, in c# unlike java it doesnt need to be private. Internally makes it private.
        public int myvalue { get; set; }
        //field
        public int myvalue2;

        //Even if u dont declare a constructor, the compiler will look at the class name and say thats the constructor.

        //Default constructor
        public Arithmetic()
        {
            myvalue = 0;
            myvalue = 0;
        }

        // Parameterised Constructor
        public Arithmetic(int x, int y)
        {
            myvalue = x;
            myvalue2 = y;
        }
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Sub(int x, int y)
        {
            return x - y;
        }

        //Deconstructor
        ~Arithmetic()
        {

        }

    }
}
