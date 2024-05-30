using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUsingBookWinForms
{
    public partial class Form1 : Form
    {
        const int portNo = 500;
        TcpClient client;
        byte[] data;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (btnSignIn.Text == "Sign in")
            {
                try
                {
                    client = new TcpClient();
                    client.Connect("127.0.0.1", portNo);
                    data = new byte[client.ReceiveBufferSize];

                    SendMessage(txtNick.Text);
                    client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), RecieveMessage, null);
                    btnSignIn.Text = "Sign out";
                    btnSend.Enabled = true;
                }
                catch (Exception rx)
                {
                    MessageBox.Show(rx.ToString());
                }
            }
            else
            {
                Disconnect();
                btnSignIn.Text = "Sign in";
                btnSend.Enabled = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(txtMsg.Text);
            txtMsg.Clear();
        }

        public void SendMessage(string message)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void RecieveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;
                bytesRead = client.GetStream().EndRead(ar);
                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    object[] para =
                    {
                        System.Text.Encoding.ASCII.GetString(data, 0, bytesRead)
                    };
                    this.Invoke(new delUpdateHistory(UpdateHistory), para);
                }
                client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), RecieveMessage, null);
            }
            catch (Exception e)
            {

            }
        }

        public delegate void delUpdateHistory(String sr);
        public void UpdateHistory(string sr)
        {
            txtMsgHistory.AppendText(sr);
        }

        public void Disconnect()
        {
            try
            {
                client.GetStream().Close();
                client.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Form_Closing(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }
    }
}
