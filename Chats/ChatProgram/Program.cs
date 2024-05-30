using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatProgram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Socket client = null;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = null;

            try
            {
                Console.WriteLine("Client 1");
                Console.WriteLine("Enter a IP addresS: ");
                string strIPAddress = Console.ReadLine();
                Console.WriteLine("Enter a port number: ");
                string strPortNumber = Console.ReadLine();
                int nPortInput = 0;

                if (strIPAddress == " ") strIPAddress = "127.0.0.1";
                if (strPortNumber == " ") strPortNumber = "25000";

                if (!IPAddress.TryParse(strIPAddress, out ipaddr))
                {
                    Console.WriteLine("Invalid server IP");
                    return;
                }

                if (!int.TryParse(strPortNumber.Trim(), out nPortInput))
                {
                    Console.WriteLine("Invalid port number");
                    return;
                }

                if (nPortInput < -0 || nPortInput > 65535)
                {
                    Console.WriteLine("Port number out of bounds");
                    return;
                }

                System.Console.WriteLine(string.Format("IPAddress: {0} - Port: {1}", ipaddr.ToString(), nPortInput));
                client.Connect(ipaddr, nPortInput);

                Console.WriteLine("Connected! enter message to send, type <x> to end");

                Task recTassk = recMessage(client);
                string input = string.Empty;

                while (true)
                {
                    input = Console.ReadLine();
                    if (input.Equals("<X>"))
                    {
                        break;
                    }

                    byte[] buffsend = Encoding.ASCII.GetBytes(input);
                    client.Send(buffsend);

                }
                await recTassk;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (client != null)
                {
                    if (client.Connected)
                    {
                        client.Shutdown(SocketShutdown.Both);
                    }
                    client.Close();
                    client.Dispose();
                }
            }

            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }

        static async Task recMessage(Socket client)
        {
            byte[] buffer = new byte[128];
            try
            {
                while (true)
                {
                    int numBytes = await client.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                    if (numBytes > 0)
                    {
                        string receivedText = Encoding.ASCII.GetString(buffer, 0, numBytes);
                        Console.WriteLine("[ {0} ]", receivedText);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }
    }
}
