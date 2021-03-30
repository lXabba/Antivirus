using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace TestConsoleServer
{
    class Program
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

        static void Main(string[] args)
        {
            CreateServerMailslot();
           
            Thread read = new Thread(ServerReadThread);
            read.Start();
            while (true)
            {

            }

            Console.Read();
        }
        public static void ServerReadThread()
        {

            while (true)
            {
                string mail = ReadMail();
                if (mail != "")
                {
                    
                    WriteMail("Hi! How are you?");

                }


            }
        }



        public static void CreateServerMailslot()
        {
            string path = "\\\\.\\mailslot\\mailServer";
            handleS = CreateMailslot(path, 0, uint.MaxValue, IntPtr.Zero);
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
                            Console.WriteLine("Read mail: " + Encoding.ASCII.GetString(buffer).Replace("\0", ""));
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
            if (!handleC.Equals(new IntPtr(-1)))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(text);

                uint dwwr = new uint() ;
                System.Threading.NativeOverlapped temp = new System.Threading.NativeOverlapped();
                Console.WriteLine("here");
               
                if (WriteFile(handleC, buffer, (uint)buffer.Length, out dwwr, ref temp))
                {
                    Console.WriteLine("Write mail: " + text);
                }
                
                    Console.WriteLine(handleC);
                    Console.WriteLine(buffer);
                    Console.WriteLine((uint)buffer.Length);
                    Console.WriteLine(dwwr);
                    Console.WriteLine(temp);

                
            }
            else Console.WriteLine("OH NOOO");
        }


    }

}