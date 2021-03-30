﻿using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace AntivirusLibrary
{
    public class MailSlotClientMethods
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

       public static bool operationDone = true;
       public static string ScanedPath;
       public static void ClientReadThread()
        {
            while (true)
            {
                string mail = ReadMail();
                if (mail.Equals("Operation done"))
                {
                    operationDone = true;
                    break;
                }
                

            }
        }
        
        public static void SendQuest(string quest)
        {
            operationDone = false;
            WriteMail(quest);
        }
       public static IntPtr CreateClientMail()
        {
            string path = "\\\\.\\mailslot\\clientmail";
            handleC = CreateMailslot(path, 0, uint.MaxValue, IntPtr.Zero);


            if (!handleC.Equals(new IntPtr(-1)))
            {
                Console.WriteLine("Created client mail.");
            }
            return handleC;

        }

       public static void CreateServerConnection()
        {
            handleS = new IntPtr(-1);
            string path = "\\\\.\\mailslot\\mailServer";
            while (handleS.Equals(new IntPtr(-1)))
            {
                handleS = CreateFile(path, FileAccess.Write,
                    FileShare.Read, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero);
            }



        }
       public static string ReadMail()
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
        public static string ReadMail(IntPtr handleCl)
        {

            if (!handleCl.Equals(new IntPtr(-1)))
            {
                uint nBytesRead;
                byte[] buffer = new byte[255];

                uint lpMaxMessageSize, lpMessageCount, lpReadTimeout;
                int lpNextSize;
                if (GetMailslotInfo(handleCl, out lpMaxMessageSize, out lpNextSize, out lpMessageCount, out lpReadTimeout))
                {
                    if (lpMessageCount > 0)
                    {
                        if (ReadFile(handleCl, buffer, 255, out nBytesRead, IntPtr.Zero))
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
