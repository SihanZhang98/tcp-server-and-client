using NewyorkAsyncSocket;
using System.Net;

namespace AsyncSocketServer
{
    public partial class Form1 : Form
    {
        NewyorkAsyncServer server;
        public Form1()
        {
            InitializeComponent();
            server = new NewyorkAsyncServer();
            server.OnServerStart += OnServerStart;
            server.OnClientConnet += OnClientConnect;
            server.OnClientDisconnect += OnClientDisonnect;
            server.OnReceiveText += OnReceiveText;
            server.OnServerStop += OnServerStop;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            server.ListenForConnection(IPAddress.Any, 23000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.StopServer();
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            server.SendMessageToAll(messageBox.Text.Trim());

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.StopServer();
        }

        private void OnReceiveText(string clientEndPoint,string receivedText)
        {
            receiverTextBox.AppendText(clientEndPoint + "   " + receivedText);
            receiverTextBox.AppendText(Environment.NewLine);
        }

        private void OnServerStart()
        {
            serverStatusLabel.Text = "Server Started";
            clientStatusLabel.Text = "No Client";
        }

        private void OnServerStop()
        {
            serverStatusLabel.Text = "Server Stopped";
        }

        private void OnClientConnect(int clientNum)
        {
            clientStatusLabel.Text= clientNum.ToString()+ " Client(s)";
        }

        private void OnClientDisonnect(int clientNum)
        {
            clientStatusLabel.Text = clientNum.ToString() + " Client(s)";
        }
    }
}