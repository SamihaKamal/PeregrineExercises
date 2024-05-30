using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Any;
            IPEndPoint ipep = new IPEndPoint(ipaddr, 25000);

            try
            {
                listenerSocket.Bind(ipep);
                listenerSocket.Listen(5);
                Socket client = listenerSocket.Accept();
                Console.WriteLine("Client connected: " + client.ToString() + " - IP end point: " + client.RemoteEndPoint.ToString());

                Socket client2 = listenerSocket.Accept();
                Console.WriteLine("Client connected: " + client2.ToString() + " - IP end point: " + client2.RemoteEndPoint.ToString());

                byte[] buff = new byte[128];
                int numrec = 0;

                byte[] buff2 = new byte[128];
                int numrec2 = 0;

                while (true)
                {
                    numrec = client.Receive(buff);
                    Console.WriteLine("number of recieved bytes: " + numrec);
                    string rectext = Encoding.ASCII.GetString(buff, 0, numrec);
                    Console.WriteLine("Data sent by client is: " + rectext);
                    client2.Send(buff);

                    if (rectext == "x")
                    {
                        break;
                    }
                    Array.Clear(buff, 0, buff.Length);
                    numrec = 0;

                    numrec2 = client2.Receive(buff2);
                    Console.WriteLine("number of recieved bytes: " + numrec2);
                    string rectext2 = Encoding.ASCII.GetString(buff2, 0, numrec2);
                    Console.WriteLine("Data sent by client is: " + rectext2);
                    client.Send(buff2);

                    if (rectext2 == "x")
                    {
                        break;
                    }


                    Array.Clear(buff2, 0, buff2.Length);
                    numrec2 = 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString);
            }
        }


    }
}
