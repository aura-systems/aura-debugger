/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Aura's Debugger!
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*                   https://msdn.microsoft.com/en-us/library/system.net.sockets.tcplistener
*/

using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Aura_Debugger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string IP = "XX.XX.XX.XX";

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                IP = endPoint.Address.ToString();
            }

            label1.Text = "Waiting at " + IP + ", " + port;
            label1.Visible = true;

            backgroundWorker1.RunWorkerAsync();

        }

        int packetnumber = 0;
        int port = 4224;

        private void backgroundWorker1_DoWork(object sen, DoWorkEventArgs e)
        {

            TcpListener server = null;
            try
            {

                server = new TcpListener(IPAddress.Any, port);

                server.Start();

                Byte[] bytes = new Byte[256];
                
                while (true)
                {
                    WriteTextBox("Waiting connection with Aura...");

                    TcpClient client = server.AcceptTcpClient();
                    WriteTextBox("Connected!");

                    NetworkStream stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        WriteTextBox(Encoding.ASCII.GetString(bytes, 0, i));

                    }

                    client.Close();
                    WriteTextBox("Connection closed!");
                }
            }
            catch (SocketException ee)
            {
                WriteTextBox("Socket Exception: " + ee);
            }
            finally
            {
                server.Stop();
                WriteTextBox("Connection closed!");
            }
        }

        void WriteTextBox(String message)
        {
            Invoke((MethodInvoker)(() =>
            {
                textBox1.Text += (@message + Environment.NewLine);
                packetnumber++;
                label2.Text = "Received logs: " + packetnumber.ToString();
            }));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (autoscroll)
            {
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            else
            {
                //Find a way to not move the bar at the top and block it
            }
        }

        bool autoscroll = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                autoscroll = false;
            }
            else
            {
                autoscroll = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            packetnumber = 0;
            label2.Text = "Received logs: 0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

    }
}
