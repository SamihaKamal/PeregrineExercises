using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming
{
    internal interface ISubtract
    {
        //A language like c# has multiple inheritence while other languages has single inheritence, if u want multiple inheritence u have to do inheritence
        //Inheritence is stating the method but not the implementation, the class that inherits must provide the implementation of the class.
        public int Sub(int x, int y);
    }
}
