using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public interface ISimpleCalculator
    {
        Task<int> add(int start, int amount);
        Task<int> subtract(int start, int amount);
        Task<int> multiply(int start, int by);
        Task<int> divide(int start, int by);
    }
}
