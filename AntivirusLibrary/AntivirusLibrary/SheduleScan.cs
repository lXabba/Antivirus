using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AntivirusLibrary
{
    public static class SheduleScan
    {
        private static Timer timer;

        public static void ScunByTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            List<string> temp = DataBaseMethods.DataBaseGetAllNotesWhere("Schedule", $"TIME='{DateTime.Now.ToString("HH:mm")}'");
            if (temp.Count == 0) return;
            List<string> filesToScan = new List<string>();
            List<string> signatures = AntivirusLibrary.DataBaseMethods.DataBaseGetOneField("Signatures", 1);
            foreach (string dir in temp)
            {
                filesToScan.AddRange(AntivirusLibrary.DirectoryAndFileMethods.GetAllFiles(dir.Split('?')[1]));
            }
            filesToScan = AntivirusLibrary.DirectoryAndFileMethods.FilesForScan(filesToScan);
            MailSlotServerMethods.FilesForScanCount = filesToScan.Count;

            foreach (string file in filesToScan)
            {
                var c = AntivirusLibrary.ScanMethods.GetScanBuffer(file);
                AntivirusLibrary.ScanMethods.ScanToQueueSchedule(c, signatures, file);
            }

            while (MailSlotServerMethods.FilesForScanCount != 0)
            {

            }



            MailSlotServerMethods.ScanStatus = true;
        }
        public static void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 30000;

            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += ScunByTimer;

            // Have the timer fire repeated events (true is the default)
            timer.AutoReset = true;

            // Start the timer
            timer.Enabled = true;
        }
    }
}
