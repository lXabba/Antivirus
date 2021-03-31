using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Net.Sockets;
namespace AntivirusService
{
    public partial class Service1 : ServiceBase
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr CreateMailslot(string lpName, uint nMaxMessageSize, uint lReadTimeout, IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(string filename, FileAccess access, FileShare share, IntPtr securityAttributes, FileMode creationDisposition, FileAttributes flagsAndAttributes, IntPtr templateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer,
        uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]
        public static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer,
        uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten,
        [In] ref System.Threading.NativeOverlapped lpOverlapped);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMailslotInfo(IntPtr hMailslot, out uint lpMaxMessageSize,
                out int lpNextSize, out uint lpMessageCount, out uint lpReadTimeout);


        static IntPtr handleS = new IntPtr(-1);
        static IntPtr handleC = new IntPtr(-1);
        static bool isRun = false;
       static StreamWriter streamWriter;
        static StreamReader streamReader;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //AntivirusLibrary.SheduleScan.StartTimer();
            //AntivirusLibrary.MailSlotServerMethods.CreateServerMailslot();
            //Thread readThread = new Thread(AntivirusLibrary.MailSlotServerMethods.ServerReadThread);
            //readThread.Start();



            if (File.Exists("D:\\log.txt")) File.Delete("D:\\log.txt");
            File.Create("D:\\log.txt").Close();
           
            //WriteFile("DeleteFile");
            //WriteFile(File.Exists("\\\\.\\mailslot\\clientmail").ToString());
           
            //CreateServerMailslot();
            //WriteFile("createMailSlot");
            isRun = true;

            //Thread thread = new Thread(Writting);
            //thread.Start();
            //WriteFile("newThread");

            Thread thread = new Thread(SocketThread);
            thread.Start();

            
        }


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
                string strvod = streamReader.ReadLine();
                WriteFile(strvod);
                networkStream.Close();
            }
        }
        protected override void OnStop()
        {
            isRun = false;
        }

        public static void WriteFile(string str)
        {
            str += "\r\n";
            //File.AppendAllText("D:\\log.txt", str + Environment.NewLine);
            using( var file = new FileStream("D:\\log.txt", FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                file.Write(Encoding.UTF8.GetBytes(str),0,str.Length);
                file.Close();
            }
           
        }
        public void Writting()
        {
            WriteFile("beforeWhile");
            WriteFile(File.Exists("\\\\.\\mailslot\\clientmail").ToString());
            while (isRun)
            {
                WriteMail("Message");
                WriteFile("whilimsia");
                
                Thread.Sleep(500);
            }
        }
        public static void ServerReadThread()
        {

            while (true)
            {
                string mail = ReadMail();
                if (mail != "")
                {

                    WriteMail("Привет! КАк дела?");

                }


            }
        }



        public static void CreateServerMailslot()
        {
            string path = "\\\\.\\mailslot\\mailServer";
           /// string path = "D:\\mailServer";
            handleS = CreateMailslot(path, 0, uint.MaxValue, IntPtr.Zero);
            WriteFile("ServerMailPath: " + path + " Server mailslot " + handleS);
            Console.WriteLine("ServerMailPath: " + path);
            Console.WriteLine("Server mailslot " + handleS);


        }
        public static void CreateClientConnection()
        {
            handleC = new IntPtr(-1);
            string path = "\\\\.\\mailslot\\clientmail";
            while (handleC.Equals(new IntPtr(-1)))
            {
                handleC = CreateFile(path, FileAccess.Write,
                    FileShare.Read, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero);
            }

            if (!handleC.Equals(new IntPtr(-1)))
            {
                Console.WriteLine("Connected to the client.");
                Console.WriteLine(handleC + "C");
            }


        }
        private static string ReadMail()
        {
            if (!handleS.Equals(new IntPtr(-1)))
            {
                uint nBytesRead;
                byte[] buffer = new byte[255];

                uint lpMaxMessageSize, lpMessageCount, lpReadTimeout;
                int lpNextSize;
                if (GetMailslotInfo(handleS, out lpMaxMessageSize, out lpNextSize, out lpMessageCount, out lpReadTimeout))
                {
                    if (lpMessageCount > 0)
                    {
                        if (ReadFile(handleS, buffer, 255, out nBytesRead, IntPtr.Zero))
                        {
                            Console.WriteLine("Read mail: " + Encoding.UTF8.GetString(buffer).Replace("\0", ""));
                            WriteFile(Encoding.UTF8.GetString(buffer).Replace("\0", ""));
                            return Encoding.ASCII.GetString(buffer).Replace("\0", "");
                        }
                    }
                }
            }
            return "";
        }

        public static void WriteMail(string text)
        {

            CreateClientConnection();
            WriteFile("Connection true "+handleC);
            if (!handleC.Equals(new IntPtr(-1)))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);

                uint dwwr = new uint();
                System.Threading.NativeOverlapped temp = new System.Threading.NativeOverlapped();
                Console.WriteLine("here");

                if (WriteFile(handleC, buffer, (uint)buffer.Length, out dwwr, ref temp))
                {
                    //Console.WriteLine();
                    WriteFile("Write mail: " + text);
                }

                


            }
            else Console.WriteLine("OH NOOO");
        }
    }
}
