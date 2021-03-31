using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace AntivirusLibrary
{
    public static class SocketServerMethods
    {
        static StreamWriter streamWriter;
        static StreamReader streamReader;
        public static bool isRun;
        public static void SocketThread()
        {
            TcpClient socketForServer;
            while (isRun)
            {
                try
                {
                    Thread.Sleep(500);
                    socketForServer = new TcpClient("localHost", 10);
                }
                catch
                {
                    continue;
                }
                NetworkStream networkStream = socketForServer.GetStream();
                streamWriter = new StreamWriter(networkStream);
                streamReader = new StreamReader(networkStream);
                string message = streamReader.ReadLine();
                MailSlotServerMethods.CheckMessage(message);
                networkStream.Close();
            }
        }
    }
}
