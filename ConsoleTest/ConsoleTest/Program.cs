﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntivirusLibrary;
using System.Threading;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //AntivirusLibrary.SheduleScan.StartTimer();
            //AntivirusLibrary.MailSlotServerMethods.CreateServerMailslot();
            //Thread readThread = new Thread(AntivirusLibrary.MailSlotServerMethods.ServerReadThread);
            //readThread.Start();
            //while (true)
            //{

            //}

            int a = 26;
            int b = 25;
            int c = (int)((double)b / a * 100);
            Console.WriteLine("k"+c);
            Console.Read();
           
        }
    }
}
