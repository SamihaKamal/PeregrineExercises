using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account myacc = new Account();
            double currentAmount = 0.0;
            currentAmount = myacc.setAccountBalance(1000.00);
            Console.WriteLine("Current amount: {0}", currentAmount);

            currentAmount = myacc.withdrawFromAccount(200.00);
            Console.WriteLine("Current amount: {0}", currentAmount);

            currentAmount = myacc.getAccountBalance();
            Console.WriteLine("Current amount: {0}", currentAmount);
            Console.ReadLine();

        }
    }
}
