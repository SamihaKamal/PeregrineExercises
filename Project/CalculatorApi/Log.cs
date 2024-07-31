using CalculatorApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class Log : ILog
    {
        private readonly LoggingContext _context;

        public Log(LoggingContext context)
        {
            _context = context;
        }
        public void LogMess(string message)
        {
            var log = new DiagnosticLog
            {
                Message = message,
                Date = DateTime.Now
            };
            _context.DI_Log.Add(log);
            _context.SaveChanges();
        }
    }
}
