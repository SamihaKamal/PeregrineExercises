using System;
using Serilog;
using Serilog.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Calculator : ICalculator
    {
        private readonly ILog _log;
        private readonly IMessage _mess;
        SqlConnection cnn;
        SqlCommand command;
        private String connString = "Data Source=.\\; Initial Catalog=Calculation;User ID=sa;Password=1234; Trust Server Certificate=True;";


        public Calculator() { }
        public Calculator(ILog log, IMessage message)
        {
            _log = log;
            _mess = message;
            Log.Logger = new LoggerConfiguration().WriteTo.Console()
                    .WriteTo.File(@"C:\Users\44747\Documents\GitHub\PeregrineExercises\Lesson\DependencyInjection\LogFile.txt")
                    .CreateLogger();
            cnn = new SqlConnection(connString);
            cnn.Open();
            Console.WriteLine("Open connection!");
        }

        void ICalculator.Add(int a, int b)
        {
            int sum = (a + b);
            string str = _mess.SendMessage($"{a} + {b} = {sum}.");
            _log.LogMess($"{str}");
            Log.Logger.Information($"Calculation: {a} + {b} = {sum}");
            string query = $"Insert Into Calculations (Result) Values ('{a} + {b} = {sum}')";
            command = new SqlCommand(query, cnn);
            command.Connection = cnn;
            command.ExecuteNonQuery();
            command.Dispose();
        }

        void ICalculator.Divide(int a, int b)
        {
            if (b == 0)
            {
                _log.LogMess("Cant divide by 0");
                Log.Logger.Error($"Cannot divide by 0");
            
            }
            else
            {
                double sum = (double)a / (double)b;
                string str = _mess.SendMessage($"{a} / {b} = {sum}");
                _log.LogMess($"{str}");
                Log.Logger.Information($"Calculation: {a} / {b} = {sum}");
                string query = $"Insert Into Calculations (Result) Values ('{a} / {b} = {sum}')";
                command = new SqlCommand(query, cnn);
                command.Connection = cnn;
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }

        public void EndConnection()
        {
            command.Dispose();
            cnn.Close();
        }
    }
}
