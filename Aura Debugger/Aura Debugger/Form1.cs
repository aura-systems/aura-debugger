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
            button1.Enabled = false;
            button2.Enabled = false;
            label1.Visible = false;

            autoscroll = true;
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
                    WriteTextBox("Waiting for a connection...");

                    TcpClient client = server.AcceptTcpClient();
                    WriteTextBox("Connected!");

                    DebuggerConnected();

                    NetworkStream stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        packetnumber++;
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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string[] splitted = textBox2.Text.Split(':');
                string ip = splitted[0];
                string port = splitted[1];

                Byte[] bytes = new Byte[256];

                while (true)
                {
                    WriteTextBox("Waiting to connect...");

                    TcpClient client = new TcpClient();

                    client.Connect(ip, int.Parse(port));

                    //label1.Text = "Connected to " + ip + ", " + port;
                    //label1.Visible = true;

                    WriteTextBox("Connected!");

                    NetworkStream stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        packetnumber++;
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
                WriteTextBox("Connection closed!");
            }
        }

        void DebuggerConnected()
        {
            Invoke((MethodInvoker)(() =>
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }));
        }

        void WriteTextBox(String message)
        {
            Invoke((MethodInvoker)(() =>
            {
                textBox1.Text += (@message + Environment.NewLine);
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

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button3.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;

            string IP = "XX.XX.XX.XX";

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                var endPoint = socket.LocalEndPoint as IPEndPoint;
                IP = endPoint.Address.ToString();
            }

            label1.Text = "Waiting at " + IP + ", " + port;
            label1.Visible = true;

            backgroundWorker1.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please specify an IP Address and Port.");
            }
            else
            {
                button4.Visible = false;
                button3.Visible = false;
                label3.Visible = false;
                textBox2.Visible = false;

                backgroundWorker2.RunWorkerAsync();
            }  
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox1.WordWrap = true;
                textBox1.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                textBox1.WordWrap = false;
                textBox1.ScrollBars = ScrollBars.Both;
            }
        }
    }
}
