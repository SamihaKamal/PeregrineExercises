using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Triangle : IShape
    {
        public double sidea { get; set; }
        public double sideb { get; set; }
        public double sidec { get; set; }
        public double s { get; set; }

        private int checkIfTriange()
        {
            s = (sidea + sideb + sidec) / 2;
            if ((s-sidea < 0) || (s-sideb < 0) || (s-sidec < 0))
            {
                return 0;
            }
            return 1;
        }
        public double Area()
        {
            int tag = checkIfTriange();
            if (tag == 0){
                return 0;
            }
            return Math.Sqrt(s * (s - sidea) * (s - sideb) * (s - sidec));
        }

        public double Perimetre()
        {
            int tag = checkIfTriange();
            if (tag == 0)
            {
                return 0;
            }
            return sidea+sideb+sidec;
        }
    }
}
