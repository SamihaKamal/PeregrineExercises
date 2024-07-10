using Serilog.Core;

namespace DependencyInjection
{
    internal class Log : ILog
    {
        public static Logger Logger { get; internal set; }

        public void LogMess(string Message)
        {
            Console.WriteLine($"message: {Message}");
        }
    }
}
