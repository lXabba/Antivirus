using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
            CreateClientMail();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            while (handleS == (new IntPtr(-1)))
            {
                CreateServerConnection();
                Console.WriteLine(handleS);
                Thread.Sleep(100);
            }
            WriteMail("1|2?Path1?Path2|2?o?i?");

            Thread thread = new Thread(ReadThread);
            thread.Start();

        }
        void ReadThread()
        {
            while (true)
            {
                string mail = ReadMail();
                if (mail != "")
                {
                    
                    textBox1.Invoke(new Action(() => textBox1.Text = mail));
                    break;
                }

            }
        }
        static void MainThread()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("1"))
                {
                    Console.WriteLine("Conection...");
                    while (handleS == (new IntPtr(-1)))
                    {
                        CreateServerConnection();
                        Console.WriteLine(handleS);
                        Thread.Sleep(100);
                    }
                    WriteMail("1|2?Path1?Path2|2?o?i?");
                }

            }
        }

        static void CreateClientMail()
        {
            string path = "\\\\.\\mailslot\\clientmail";
            handleC = CreateMailslot(path, 0, uint.MaxValue, IntPtr.Zero);


            if (!handleC.Equals(new IntPtr(-1)))
            {
                Console.WriteLine("Created client mail.");
            }

        }

        static void CreateServerConnection()
        {
            string path = "\\\\.\\mailslot\\mailServer";
            handleS = CreateFile(path, FileAccess.Write,
                FileShare.Read, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero);


            if (!handleS.Equals(new IntPtr(-1)))
            {
                Console.WriteLine("Connected to the server.");
            }


        }
        static string ReadMail()
        {

            if (!handleC.Equals(new IntPtr(-1)))
            {
                uint nBytesRead;
                byte[] buffer = new byte[255];

                uint lpMaxMessageSize, lpMessageCount, lpReadTimeout;
                int lpNextSize;
                if (GetMailslotInfo(handleC, out lpMaxMessageSize, out lpNextSize, out lpMessageCount, out lpReadTimeout))
                {
                    if (lpMessageCount > 0)
                    {
                        if (ReadFile(handleC, buffer, 255, out nBytesRead, IntPtr.Zero))
                        {
                            Console.WriteLine("Read mail: " + Encoding.ASCII.GetString(buffer).Replace("\0", ""));
                            return Encoding.ASCII.GetString(buffer).Replace("\0", "");
                        }
                    }
                }
            }
            return "";
        }

        static void WriteMail(string text)
        {
            if (!handleS.Equals(new IntPtr(-1)))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(text);

                uint dwwr;
                System.Threading.NativeOverlapped temp = new System.Threading.NativeOverlapped();
                if (WriteFile(handleS, buffer, (uint)buffer.Length, out dwwr, ref temp))
                {
                    Console.WriteLine("Write mail: " + text);
                }
            }
        }


    }
}
