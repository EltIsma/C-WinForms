using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace rwplab3
{


    

    public class Client
    {

        public string myIp { get; private set; }
        public int port { get; set; }
        public bool clientStatus = true;
        private TcpClient socketForServer;

        public Socket socketForClient { get; set; }
        public NetworkStream networkStream { get; set; }
        public StreamReader streamReader { get; set; }
        public StreamWriter streamWriter { get; set; }
        public Client(string myIp, int port)
        {
            this.myIp = myIp;
            this.port = port;
        }

        public void ConnectToserver()
        {
            try
            {
                socketForServer = new TcpClient(myIp, port);
            }
            catch
            {

            }
        }

        public void serverData()
        {
            networkStream = socketForServer.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
        }
        public void disconect()
        {
            networkStream.Close();
            streamReader.Close();
            streamWriter.Close();
            socketForClient.Close();
        }
    }
}
