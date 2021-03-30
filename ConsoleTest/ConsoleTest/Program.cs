using System;
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
            //Thread monitorThread = new Thread(MailSlotServerMethods.StartMonitoringServer);
            //monitorThread.Start();
            MailSlotServerMethods.StartMonitoringServer();
            AntivirusLibrary.MailSlotServerMethods.CreateServerMailslot();
            Thread readThread = new Thread(AntivirusLibrary.MailSlotServerMethods.ServerReadThread);
            readThread.Start();
            while (true)
            {

            }



            Console.Read();
        }
    }
}
