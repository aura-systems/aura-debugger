/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Aura's Debugger!
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
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

            label1.Text = "Waiting at " + IP + ", 4224";
            label1.Visible = true;

            backgroundWorker1.RunWorkerAsync();
        }

        private void UpdateStatus(string status)
        {
            textBox1.Text += status + Environment.NewLine;
        }

        private void backgroundWorker1_DoWork(object sen, DoWorkEventArgs e)
        {

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 4224);

            UdpClient newsock = new UdpClient(ipep);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    newsock.Close();
                    return;
                }

                byte[] data = newsock.Receive(ref sender);

                WriteTextBox(Encoding.ASCII.GetString(data));
            }

            void WriteTextBox(String message)
            {
                Invoke((MethodInvoker)(() =>
                {
                    textBox1.Text += message + Environment.NewLine;
                }));
            }
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
    }
}
