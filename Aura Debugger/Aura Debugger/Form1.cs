﻿/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Aura's Debugger!
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*                   https://msdn.microsoft.com/en-us/library/system.net.sockets.tcplistener
*/

using System;
using System.IO;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Drawing;

namespace Aura_Debugger
{
    public partial class Form1 : Form
    {
        private bool autoscroll;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnClear.Enabled = false;
            BtnCopy.Enabled = false;
            LabelStatus.Visible = false;

            autoscroll = true;
            ConfigManager.LoadConfig();

            NetworkManager.WriteInfo("Ready to connect");
        }

        // wait for connection
        private void WorkerWait_DoWork(object sen, DoWorkEventArgs e)
        {
            NetworkManager.WaitForConnection();
        }

        // connect
        private void WorkerConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            NetworkManager.Connect(TxtIP.Text);
        }

        public void ResetState()
        {
            Invoke((MethodInvoker)(() =>
            {
                if (TxtOutput.Text.Length == 0)
                {
                    BtnClear.Enabled = false;
                    BtnCopy.Enabled = false;
                }
                TxtIP.Enabled = true;
                BtnWait.Enabled = true;
                BtnConnect.Enabled = true;

                BtnConnect.Text = "Connect";
                BtnConnect.ForeColor = Color.LawnGreen;
            }));
        }

        public void ConnectedState()
        {
            Invoke((MethodInvoker)(() =>
            {
                BtnClear.Enabled = true;
                BtnCopy.Enabled = true;
                TxtIP.Enabled = false;
                BtnWait.Enabled = false;

                BtnConnect.Text = "Disconnect";
                BtnConnect.ForeColor = Color.Tomato;
            }));
        }

        public void WriteTextBox(string message)
        {
            WriteTextBox(message, Color.White);
        }

        public void WriteTextBox(string message, Color color)
        {
            Invoke((MethodInvoker)(() =>
            {
                TxtOutput.SelectionStart = TxtOutput.TextLength;
                TxtOutput.SelectionLength = 0;

                TxtOutput.SelectionColor = color;
                TxtOutput.AppendText(message);
                TxtOutput.SelectionColor = TxtOutput.ForeColor;
            }));
        }

        public void ClearLog()
        {
            Invoke((MethodInvoker)(() =>
            {
                NetworkManager.PacketNumber = 0;
                TxtOutput.Clear();
                LabelReceived.Text = "Received Logs: 0";
            }));
        }
        
        public bool GetWordWrap()
        {
            return TxtOutput.WordWrap;
        }

        public bool GetAutoScroll()
        {
            return autoscroll;
        }

        public void SetWordWrap(bool wrap)
        {
            Invoke((MethodInvoker)(() =>
            {
                if (wrap)
                {
                    TxtOutput.WordWrap = true;
                    TxtOutput.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
                    ChkWordWrap.Checked = true;
                }
                else
                {
                    TxtOutput.WordWrap = false;
                    TxtOutput.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
                    ChkWordWrap.Checked = false;
                }
            }));
        }

        public void SetAutoScroll(bool autoscrl)
        {
            Invoke((MethodInvoker)(() =>
            {
                autoscroll = autoscrl;
                ChkAutoScroll.Checked = autoscroll;
            }));
        }

        private void TxtOutput_TextChanged(object sender, EventArgs e)
        {
            if (autoscroll)
            {
                TxtOutput.SelectionStart = TxtOutput.Text.Length;
                TxtOutput.ScrollToCaret();
            }
        }

        private void ChkAutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            SetAutoScroll(ChkAutoScroll.Checked);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TxtOutput.Text);
        }

        private void BtnWait_Click(object sender, EventArgs e)
        {
            ConnectedState();

            string IP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                var endPoint = socket.LocalEndPoint as IPEndPoint;
                IP = endPoint.Address.ToString();
            }

            LabelStatus.Text = "Waiting at " + IP + ", " + NetworkManager.Port;
            LabelStatus.Visible = true;

            WorkerWait.RunWorkerAsync();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (TxtIP.Text.Length == 0)
            {
                MessageBox.Show("Please specify an IP address and port");
            }
            else
            {
                ConnectedState();
                WorkerConnect.RunWorkerAsync();
            }  
        }

        private void ChkWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            SetWordWrap(ChkWordWrap.Checked);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigManager.SaveConfig();
        }
    }
}
