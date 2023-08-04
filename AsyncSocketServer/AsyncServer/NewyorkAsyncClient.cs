using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewyorkAsyncSocket
{
    public class NewyorkAsyncClient
    {
        public IPAddress IP { get; private set; }

        public int Port { get; private set; }
        public TcpClient Client { get; private  set; }
        public bool IsRunning { get; set; }

        public Action OnConnectedToServer;
        public Action OnDisconnectedToServer;
        public Action<string> OnReceiveMessage;

        public async void ConnectToServer(IPAddress ip, int port)
        {
            IsRunning = true;
            IP= ip;
            Port= port;

            //create new client
            Client = new TcpClient();

            try
            {
                //connect to server ip and port
                await Client.ConnectAsync(IP, Port);
                Console.WriteLine("Connected to Server, IP: {0}, Port {1}", IP, Port);

                OnConnectedToServer();

                //receive data from server
                HandleServerData(Client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



        }

        private async void HandleServerData(TcpClient client)
        {
            NetworkStream stream = null;
            StreamReader streamReader = null;

            try
            {
                stream = client.GetStream();
                streamReader = new StreamReader(stream);

                char[] buffer = new char[128];

                while (IsRunning)
                {
                    //read stream form server
                    int nReturn = await streamReader.ReadAsync(buffer, 0, buffer.Length);

                    if(nReturn == 0)
                    {
                        Console.WriteLine("Server disconnected!");

                        OnDisconnectedToServer();

                        break;
                    }

                    string text = new string(buffer);
                    Console.WriteLine("Received text : {0}", text);

                    OnReceiveMessage(text);

                    Array.Clear(buffer);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async void SendMessageToServer(string message)
        {
            if (message == null)
            {
                return;
            }

            try
            {
                byte[] buffMessage = Encoding.ASCII.GetBytes(message);
  
                Client.GetStream().WriteAsync(buffMessage);
             
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        } 

        public void StopClient()
        {
            if (Client != null)
            {
                Client.Close();
                IsRunning= false;
            }

        }
    }
}
