﻿using System;
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


        static IntPtr handleS;
        static IntPtr handleC = new IntPtr(-1);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int command = 1;
            string mail = command+"|2?Path1?Path2|"+getOptions();


            CreateClientMail();
            while (handleC.Equals(new IntPtr(-1)))
            {
                CreateServerConnection();
            }
            textBox2.Text = handleC.ToString();
            WriteMail(mail);
        }

        string getOptions()
        {
            string str = "";
            int count = 0;
            for (int i = 0; i < 2; i++)
            {
                if (((RadioButton)panel1.Controls[i]).Checked == true)
                {
                    str += i + "?";
                    count++;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                if (((RadioButton)panel2.Controls[i]).Checked == true)
                {
                    str += i + "?";
                    count++;
                }
            }
            return count+"?"+str;
        }
        void CreateClientMail()
        {
            string path = "\\\\.\\mailslot\\clientmail";
            handleS = CreateMailslot(path, 0, uint.MaxValue, IntPtr.Zero);
            

            if (!handleS.Equals(new IntPtr(-1)))
            {
                textBox1.Text = "Created client mail.";
            }
            else textBox1.Text = "Not Created client mail.";
        }

        void CreateServerConnection()
        {
            string path = "\\\\.\\mailslot\\servermail";
            handleC = CreateFile(path, FileAccess.Write,
                FileShare.Read, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero);
           

            if (!handleC.Equals(new IntPtr(-1)))
            {
                textBox1.Text = "Connected to the server.";
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
