using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Message : IMessage
    {
        public string SendMessage(string mess)
        {
            Console.Write($"message: {mess}");
            return "sent";
        }
    }
}
