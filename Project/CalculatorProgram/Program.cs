using CalculatorApi;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using CalculatorApi.Context;
using Microsoft.EntityFrameworkCore;

namespace CalculatorProgram
{
    internal class Program
    {
        public static IContainer Container { get; private set; }
        static async Task Main(string[] args)
        {

            var containerBulder = new ContainerBuilder();

            //DBcontext register
            string connectionString = "Data Source=.\\; Initial Catalog=Logging;User ID=sa;Password=1234; Trust Server Certificate=True;";
           /* containerBulder.Populate(new ServiceCollection().AddDbContext<LoggingContext>(options =>
            options.UseSqlServer(connectionString)));
*/
            //register the interfaces and make a single instance of them
            containerBulder.RegisterType<LogSP>().As<ILog>().WithParameter("connectionString", connectionString).SingleInstance();
            containerBulder.RegisterType<SimpleCalculator>().As<ISimpleCalculator>().SingleInstance();

            Container = containerBulder.Build();
            Console.WriteLine("container built");


            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ISimpleCalculator>();
                int result = 0;
                Console.WriteLine("Do you want to \n (a) Add \n (b) Subtract \n (c) Divide \n (d) Multiply? " +
                    "Type the letter that corresponds to the option.");
                string userInput = Console.ReadLine();
                Console.WriteLine("Enter first number: ");
                int firstNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number: ");
                int secondNumber = Convert.ToInt32(Console.ReadLine());
                if (userInput.ToUpper() == "A")
                {
                    result = await calc.add(firstNumber, secondNumber);
                }
                else if (userInput.ToUpper() == "B")
                {
                    result = await calc.subtract(firstNumber, secondNumber);
                }
                else if (userInput.ToUpper() == "C")
                {
                    result = await calc.divide(firstNumber, secondNumber);
                   
                }
                else if (userInput.ToUpper() == "D")
                {
                    
                    result = await calc.multiply(firstNumber, secondNumber);
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }

                if (result != -1)
                {
                    Console.WriteLine("Result is " + result);
                }
              
            }


            
            
        }
    }
}
