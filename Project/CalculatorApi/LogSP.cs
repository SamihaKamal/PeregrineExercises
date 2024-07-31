using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class LogSP : ILog
    {
        private readonly string _connectionString;

        public LogSP(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void LogMess(string Message)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("LogMessage", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Message", Message);
                    command.Parameters.AddWithValue("@LogDate", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }

            
        }
    }
}
