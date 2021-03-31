using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace AntivirusLibrary
{

    public static class SocketClientMethods
    {
        static TcpListener tcpListener = new TcpListener(10);
        static StreamWriter streamWriter;
        static StreamReader streamReader;

        public static void SocketClientWriteMessage(string message)
        {
            tcpListener.Start();
            Socket socketForClient = tcpListener.AcceptSocket();
            if (socketForClient.Connected)
            {
                NetworkStream networkStream = new NetworkStream(socketForClient);
                StreamWriter streamWriter = new StreamWriter(networkStream);
                StreamReader streamReader = new StreamReader(networkStream);

                streamWriter.WriteLine(message);
                streamWriter.Flush();
                streamWriter.Close();
                streamReader.Close();
                networkStream.Close();
                tcpListener.Stop();
                socketForClient.Close();
            }
        }
    }
}
