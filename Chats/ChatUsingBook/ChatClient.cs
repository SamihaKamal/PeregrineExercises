using System;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading.Tasks.Dataflow;

namespace ChatUsingBook
{
    class ChatClient
    {
        public static Hashtable AllClients = new Hashtable();

        private TcpClient _client;
        private string _clientIP;
        private string _clientNick;

        private byte[] data;

        private bool recieveNick = true;

        public ChatClient(TcpClient client)
        {
            _client = client;
            _clientIP = client.Client.RemoteEndPoint.ToString();
            AllClients.Add(_clientIP, this);
            data = new byte[_client.ReceiveBufferSize];
            client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(_client.ReceiveBufferSize), RecieveMessage, null);
        }

        public void RecieveMessage(IAsyncResult ar)
        {
            int bytesRead;
            try
            {
                lock (_client.GetStream())
                {
                    bytesRead = _client.GetStream().EndRead(ar);
                }
                if(bytesRead < 1)
                {
                    AllClients.Remove(_clientIP);
                    Broadcast(_clientNick + " has left the chat (cause your stinky)");
                    return;
                }
                else
                {
                    string mesRec = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    if (recieveNick)
                    {
                        _clientNick = mesRec;
                        Broadcast(_clientNick + " has joined the chat (your not stinky anymore!)");
                        recieveNick = false;
                    }
                    else
                    {
                        Broadcast(_clientNick + ">" + mesRec);
                    }
                }

                lock (_client.GetStream())
                {
                    _client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(_client.ReceiveBufferSize), RecieveMessage, null);
                }
            }
            catch (Exception e)
            {
                AllClients.Remove(_clientIP);
                Broadcast(_clientNick + "has left the chat");
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                System.Net.Sockets.NetworkStream ns;
                lock (_client.GetStream())
                {
                    ns = _client.GetStream();
                }

                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                ns.Write(bytesToSend, 0, bytesToSend.Length);
                ns.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Broadcast(string message)
        {
            Console.WriteLine(message);
            foreach (DictionaryEntry c in AllClients)
            {
                ((ChatClient)(c.Value)).SendMessage(message + Environment.NewLine);
            }
        }
    }
}
