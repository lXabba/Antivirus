using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace AntivirusLibrary
{
    class MailSlotServerMethods
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
        static void ServerReadThread()
        {
            
            while (true)
            {
                string mail = ReadMail();
                if (mail != "")
                {

                    Quest quest = new Quest(int.Parse(mail.Split('|')[0]));
                    for (int i = 1; i <= int.Parse(mail.Split('|')[1].Split('?')[0]); i++)
                    {
                        quest.setPaths(mail.Split('|')[1].Split('?')[i]);
                    }
                    for (int i = 1; i <= int.Parse(mail.Split('|')[2].Split('?')[0]); i++)
                    {
                        quest.setOptions(mail.Split('|')[2].Split('?')[i]);
                    }
                    quest.Show();

                    WriteMail("Operation done");
                }
            }
        }
        static void CreateServerMailslot()
        {
            string path = "\\\\.\\mailslot\\mailServer";
            handleS = CreateMailslot(path, 0, uint.MaxValue, IntPtr.Zero);
            Console.WriteLine("ServerMailPath: " + path);


        }
        static void CreateClientConnection()
        {
            string path = "\\\\.\\mailslot\\clientmail";
            handleC = CreateFile(path, FileAccess.Write,
                FileShare.Read, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero);


            if (!handleC.Equals(new IntPtr(-1)))
            {
                Console.WriteLine("Connected to the client.");
                Console.WriteLine(handleC + "C");
            }


        }
        static string ReadMail()
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

        static void WriteMail(string text)
        {
            if (!handleC.Equals(new IntPtr(-1)))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(text);

                uint dwwr;
                System.Threading.NativeOverlapped temp = new System.Threading.NativeOverlapped();
                if (WriteFile(handleC, buffer, (uint)buffer.Length, out dwwr, ref temp))
                {
                    Console.WriteLine("Write mail: " + text);
                }
            }
        }
    }

    class Quest
    {
        int command;
        List<string> paths;
        List<string> options;

        public Quest(int command)
        {
            this.command = command;
            paths = new List<string>();
            options = new List<string>();
        }
        public void setPaths(string path)
        {
            paths.Add(path);
        }
        public void setOptions(string option)
        {
            options.Add(option);
        }
        public void Show()
        {
            Console.WriteLine("command: " + command);
            for (int i = 0; i < paths.Count; i++)
            {
                Console.WriteLine("path: " + paths[i]);
            }
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine("option: " + options[i]);
            }
        }
    }
}
