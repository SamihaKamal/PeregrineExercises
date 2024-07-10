using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Dependancy Injection example");
            //Instantitate cotnainer
            var containerBulder = new ContainerBuilder();

            //register the interfaces and make a single instance of them
            containerBulder.RegisterType<Message>().As<IMessage>().SingleInstance();
            containerBulder.RegisterType<Log>().As<ILog>().SingleInstance();
            containerBulder.RegisterType<Calculator>().As<ICalculator>().SingleInstance();

            var container = containerBulder.Build();
            Console.WriteLine("cotnianer built");

            var calc = container.Resolve<ICalculator>();

            //START
            int a = 0, b = 0;
            Console.Write("Enter firstnumber: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number : ");
            b = Convert.ToInt32(Console.ReadLine());

            calc.Add(a, b);
            calc.Divide(a, b);
            calc.EndConnection();
            Console.WriteLine("done");
            Console.ReadLine();

        }
    }
}
