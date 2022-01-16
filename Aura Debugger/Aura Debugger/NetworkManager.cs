using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Drawing;

namespace Aura_Debugger
{
    public static class NetworkManager
    {
        public static TcpListener Listener;
        public static TcpClient Client;

        public static string IP;
        public static int Port;
        public static int PacketNumber;
        public static bool Connected;
        public static bool Waiting;

        public static void Initialize()
        {
            // reset values
            Listener = null;
            Client = null;
            PacketNumber = 0;
            Port = 0;
            IP = "0.0.0.0";

            // not connected
            Connected = false;
            Waiting = false;
        }

        public static void WriteToLog(string text)
        {
            Program.MainForm.WriteTextBox(text);
        }

        public static void WriteInfo(string text)
        {
            Program.MainForm.WriteTextBox("[  ");
            Program.MainForm.WriteTextBox(">>>", Color.Cyan);
            Program.MainForm.WriteTextBox("  ] ");
            Program.MainForm.WriteTextBox(text + Environment.NewLine);
        }

        public static void WriteError(string text)
        {
            Program.MainForm.WriteTextBox("[ ");
            Program.MainForm.WriteTextBox("ERROR", Color.Red);
            Program.MainForm.WriteTextBox(" ] ");
            Program.MainForm.WriteTextBox(text + Environment.NewLine);
        }

        public static void WaitForConnection()
        {
            Listener = null;
            Waiting = true;

            try
            {
                Listener = new TcpListener(IPAddress.Any, Port);
                Listener.Start();

                int i = 0;
                byte[] bytes = new byte[256];

                while (true)
                {
                    WriteInfo("Waiting for a connection...");
                    Program.MainForm.WaitState();

                    Client = Listener.AcceptTcpClient();
                    WriteInfo("Connected!");

                    Connected = true;
                    Waiting = false;
                    Program.MainForm.ConnectedState();

                    NetworkStream stream = Client.GetStream();
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        PacketNumber++;
                        WriteToLog(Encoding.ASCII.GetString(bytes, 0, i));
                    }

                    Client.Close();
                    WriteInfo("Connection closed!");
                    Program.MainForm.ResetState();
                    Connected = false;
                }
            }
            // socket exception error
            catch (SocketException e) 
            {
                if (e.SocketErrorCode == SocketError.Interrupted) { }
                else { WriteError("Socket Exception: " + e); }
                Program.MainForm.ResetState();
                Waiting = false;
                Connected = false;
            }
            // stop listening and print message
            finally 
            {
                Listener.Stop();
                WriteInfo("Connection closed!");
                Program.MainForm.ResetState();
                Waiting = false;
                Connected = false;
            }
        }

        public static void Connect(string addr)
        {
            Waiting = true;

            // parse input string
            string[] parts = addr.Split(':');
            string ip = string.Empty;
            string port = string.Empty;

            if (parts.Length >= 1) { ip = parts[0]; }
            if (parts.Length >= 2) { port = parts[1]; }

            // set ip
            IP = ip;

            // parse and set port
            if (!int.TryParse(port, out Port)) 
            { 
                WriteError("Invalid port " + port);
                Program.MainForm.ResetState();
                return; 
            }

            // validate port
            if (Port >= 0xFFFF)
            { 
                WriteError("Invalid port " + Port.ToString());
                Program.MainForm.ResetState();
                return;
            }

            try
            {
                int i = 0;
                byte[] bytes = new byte[256];

                while (true)
                {
                    WriteInfo("Waiting to connect...");
                    Program.MainForm.ConnectingState();

                    Client = new TcpClient();
                    Client.Connect(ip, Port);

                    WriteInfo("Connected!");
                    Connected = true;
                    Waiting = false;
                    Program.MainForm.ConnectedState();

                    NetworkStream stream = Client.GetStream();
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        PacketNumber++;
                        WriteToLog(Encoding.ASCII.GetString(bytes, 0, i));
                    }

                    Client.Close();
                    WriteInfo("Connection closed!");
                    Program.MainForm.ResetState();
                    Connected = false;
                }
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.Interrupted) { }
                else { WriteError("Socket Exception: " + e); }
                Program.MainForm.ResetState();
                Waiting = false;
                Connected = false;
            }
            finally
            {
                WriteInfo("Connection closed!");
                Program.MainForm.ResetState();
                Waiting = false;
                Connected = false;
            }
        }
    }
}
