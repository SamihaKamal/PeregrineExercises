using Serilog;
using Serilog.Core;
using System;

namespace CoreLogging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            {
                Log.Logger = new LoggerConfiguration().WriteTo.Console()
                    .WriteTo.File(@"C:\Users\44747\Documents\GitHub\PeregrineExercises\Lesson\LogFile.txt")
                    .CreateLogger();
                for (int x = 0; x < 2; x++)
                {
                    Log.Information($"Hello, serilog, {x}");
                    Log.Warning($"Goodbye serilog. {x}");
                    Log.Information($"Time to add two numbers: {DateTime.Now.ToUniversalTime()} , {x}");
                    Log.Verbose($"Verbose log message: {x}");
                }

                Log.CloseAndFlush();
                Console.WriteLine("-------------------");
                ReadfromFile();
                Console.ReadLine();
            }
        }

        private static void ReadfromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\44747\Documents\GitHub\PeregrineExercises\Lesson\LogFile.txt");
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
        }
    }
}
