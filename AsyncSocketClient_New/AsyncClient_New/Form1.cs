using NewyorkAsyncSocket;
using System.Net;
using Tulpep.NotificationWindow;

namespace AsyncClient_New
{
    public partial class Form1 : Form
    {
        NewyorkAsyncClient client;


        public Form1()
        {
            InitializeComponent();
            client = new NewyorkAsyncClient();
            client.OnConnectedToServer += OnConnectedToServer;
            client.OnDisconnectedToServer+= OnDisconnectedToServer;
            client.OnReceiveMessage+= OnReceiveMessage; 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.SendMessageToServer(msgBox.Text);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            int port;
            PopupNotifier popup;

            if (!IPAddress.TryParse(ipBox.Text, out ip))
            {
                popup = new PopupNotifier();
                popup.ContentText = "Invalid address!";
                popup.Popup();
                return;
            };

            if (!int.TryParse(portBox.Text, out port))
            {
                popup = new PopupNotifier();
                popup.ContentText = "Invalid port!";
                popup.Popup();
                return;
            }

            if (port <= 0 || port > 65553)
            {
                popup = new PopupNotifier();
                popup.ContentText = "Invalid port!";
                popup.Popup();
                return;
            }

            client.ConnectToServer(ip, port);
        }

        private void OnConnectedToServer()
        {
            statusLabel.Text = "Connected to Server";
        }

        private void OnReceiveMessage(string msg)
        {
            receivedMsgBox.AppendText(msg);
            receivedMsgBox.AppendText(Environment.NewLine);
        }

        private void OnDisconnectedToServer()
        {
            statusLabel.Text = "server disconnected";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.StopClient();
        }
    }
}