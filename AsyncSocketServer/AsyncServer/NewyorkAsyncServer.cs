using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;

namespace NewyorkAsyncSocket {
    public class NewyorkAsyncServer
    {
        IPAddress ip;
        int port;
        TcpListener tcpListener;
        bool isRunning;
        List<TcpClient> clients;

        public Action OnServerStart;
        public Action OnServerStop;
        public Action <int> OnClientConnet;
        public Action <int> OnClientDisconnect;
        public Action<string,string> OnReceiveText;



        public NewyorkAsyncServer()
        {
            clients = new List<TcpClient>();
        }

        public async void ListenForConnection(IPAddress ip, int port)
        {
            this.ip = ip;
            this.port = port;

            
            //create new tcp listener
            tcpListener  = new TcpListener(ip, port);

            try
            {

                tcpListener.Start();
                isRunning = true;
                Debug.WriteLine("Server Started!");

                //raise server start event
                OnServerStart();

              
                while (isRunning)
                {
    
                    //receive client connection asynchronously
                    TcpClient receivedClient = await tcpListener.AcceptTcpClientAsync();
                    System.Diagnostics.Debug.WriteLine("Client Connected, Client Name: {0}, Endpoint: {1} " 
                        ,receivedClient,receivedClient.Client.RemoteEndPoint);

                    if (!clients.Contains(receivedClient))
                    {
                        //add client to list
                        clients.Add(receivedClient);

                        //raise event when client is connected
                        //parameter is the number of current clients 
                        OnClientConnet(clients.Count);
                    }
                
                    foreach(TcpClient c in clients)
                    {
                        //handle data sent from client
                        HandleClientData(receivedClient);
                    }

                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
            }
                      
        }

        public async void HandleClientData(TcpClient client)
        {
            NetworkStream stream = null;
            StreamReader streamReader = null;

            try
            {
                
                stream = client.GetStream();
                streamReader = new StreamReader(stream);

                char[] buffer = new char[128];

                while (isRunning)
                {

                    //read stream form client
                    int nReturn = await streamReader.ReadAsync(buffer, 0, buffer.Length);

                    if (nReturn == 0)
                    {
                        RemoveClient(client);
                        Debug.WriteLine("Socket Disconnected");

                        OnClientDisconnect(clients.Count);
                        break;
                    }

                    //convert characters to string
                    string text = new string(buffer);
                    Debug.WriteLine($"   Received text: {0}   " , text );

                    string clientEndPoint = client.Client.RemoteEndPoint.ToString();

                    //raise receive text event
                    OnReceiveText(clientEndPoint,text);

                    //clear buffer
                    Array.Clear(buffer);
                }

        
            }
            catch (Exception e)
            {

               Debug.WriteLine(e);
            }



        }

        public void StopServer()
        {
            if(tcpListener!=null)
            {
                tcpListener.Stop();
                isRunning = false;
                Debug.WriteLine("Server Stopped!");

                //raise server stop event
                OnServerStop();
            }

            foreach (TcpClient c in clients)
            {
                c.Close();
            }

            clients.Clear();
        }

        private void RemoveClient(TcpClient client)
        {
            if (clients.Contains(client))
            {
                clients.Remove(client);
            }
        }

        public async void SendMessageToAll(string message)
        {
            if(message == null)
            {
                return;
            }

            try
            {
                byte[] buffMessage= Encoding.ASCII.GetBytes(message);
                foreach(TcpClient c in clients)
                {
                    c.GetStream().WriteAsync(buffMessage);
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
            }
        }
    }
}