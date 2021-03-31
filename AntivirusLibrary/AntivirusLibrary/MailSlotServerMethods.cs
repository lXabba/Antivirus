using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Timers;

namespace AntivirusLibrary
{
    public static class MailSlotServerMethods
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

        enum Command {
        START_SCAN_DIR = 0,
        DELETE_FILES = 1,
        QUARANTINE_FILE = 2,
        IGNOR_FILE = 3,
        START_MONITORING = 4,
        STOP_MONITORING = 5,
        GET_SCAN_STATUS = 6,
        GET_SCAN_PROGRESS = 7,

            }

        public static int FilesForScanCount = 0;
        public static bool ScanStatus = false;

      public  static List<MonitoringMethods> listMonitoring = new List<MonitoringMethods>();
       public static void ServerReadThread()
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
                        Console.WriteLine(mail.Split('|')[1]);
                    }
                    for (int i = 1; i <= int.Parse(mail.Split('|')[2].Split('?')[0]); i++)
                    {
                        quest.setOptions(mail.Split('|')[2].Split('?')[i]);
                    }
                    quest.Show();

                    switch (quest.command)
                    {
                        case 0:
                            DataBaseMethods.DataBaseDeleteAllNotes("Scan");
                            StartScanDir(quest);
                            break;
                        case 1:
                            DeleteFiles(quest);
                            break;
                        case 2:
                            QuarantineFiles(quest);
                            break;
                        case 3:
                            IgnorFiles(quest);
                            break;
                        case 4:
                            StartMonitoring(quest);
                            break;
                        case 5:
                            StopMonitoring();
                            break;
                        case 6:
                            var status = GetScanStatus();
                            WriteMail("Status_" + status);
                            break;
                        case 7:
                            GetScanProgress();

                            break;
                        case 8:
                            ScanMethods.StopScan();
                            break;

                        case 9:
                            Recover(quest);
                            break;
                        default:
                            break;
                    }

                    
                }
            }
        }
        public static void CheckMessage(string mail)
        {
            
            if (mail != "")
            {

                Quest quest = new Quest(int.Parse(mail.Split('|')[0]));

                for (int i = 1; i <= int.Parse(mail.Split('|')[1].Split('?')[0]); i++)
                {
                    quest.setPaths(mail.Split('|')[1].Split('?')[i]);
                    Console.WriteLine(mail.Split('|')[1]);
                }
                for (int i = 1; i <= int.Parse(mail.Split('|')[2].Split('?')[0]); i++)
                {
                    quest.setOptions(mail.Split('|')[2].Split('?')[i]);
                }
                quest.Show();

                switch (quest.command)
                {
                    case 0:
                        DataBaseMethods.DataBaseDeleteAllNotes("Scan");
                        StartScanDir(quest);
                        break;
                    case 1:
                        DeleteFiles(quest);
                        break;
                    case 2:
                        QuarantineFiles(quest);
                        break;
                    case 3:
                        IgnorFiles(quest);
                        break;
                    case 4:
                        StartMonitoring(quest);
                        break;
                    case 5:
                        StopMonitoring();
                        break;
                    case 6:
                        var status = GetScanStatus();
                       // WriteMail("Status_" + status);
                        break;
                    case 7:
                        GetScanProgress();

                        break;
                    case 8:
                        ScanMethods.StopScan();
                        break;

                    case 9:
                        Recover(quest);
                        break;
                    default:
                        break;
                }


            }
        }

       private static void Recover(Quest quest)
        {
            List<string> paths = quest.getPaths();

            foreach (string file in paths)
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                string time = DateTime.Now.ToString("H:mm");
                AntivirusLibrary.FileManipulation.FileManipulationRecover(file);
                AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "QUARANTINE");

            }
        }
       private static void StartScanDir(Quest quest)
        {
            
            ScanStatus = true;
            Thread thread = new Thread(ThreadScan);
            thread.Start(quest);
            

        }

        private static void ThreadScan(object obj)
        {
            Quest quest = (Quest)obj;
            List<string> signatures = AntivirusLibrary.DataBaseMethods.DataBaseGetOneField("Signatures", 1);
            List<string> paths = quest.getPaths();
            List<string> filesToScan = new List<string>();
           
            foreach (string dir in paths)
            {
                if (!ScanStatus) return;
                filesToScan.AddRange(AntivirusLibrary.DirectoryAndFileMethods.GetAllFiles(dir));
            }
            filesToScan = AntivirusLibrary.DirectoryAndFileMethods.FilesForScan(filesToScan);
            FilesForScanCount = filesToScan.Count;

            foreach (string file in filesToScan)
            {
                if (!ScanStatus) return;
                var c = AntivirusLibrary.ScanMethods.GetScanBuffer(file);
                AntivirusLibrary.ScanMethods.ScanToQueue(c, signatures, file);
            }

            while (FilesForScanCount != 0)
            {

            }


            WriteMail("Operation done");
        }
       private static void DeleteFiles(Quest quest)
        {
            List<string> paths = quest.getPaths();
            quest.Show();
            foreach (string file in paths)
            {
                var monitoringObject = GetMonitoringObject(file);
                if (monitoringObject != null)
                {
                    monitoringObject.StopMonitoring();
                    AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "Monitoring");
                }

                AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "Quarantine");
                AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "Schedule");
                AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "ScheduleReport");
                AntivirusLibrary.FileManipulation.FileManipulationDelete(file);
            }
        }

       private static void QuarantineFiles(Quest quest)
        {
            List<string> paths = quest.getPaths();

            foreach (string file in paths)
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                string time = DateTime.Now.ToString("H:mm");
                AntivirusLibrary.FileManipulation.FileManipulationQuarantine(file);
                AntivirusLibrary.DataBaseMethods.AddNote("QUARANTINE", "PATH,VIRUSTYPE,DATE,TIME", $"'{file}','virus','{date}','{time}'");
                
            }
        }

      private static void IgnorFiles(Quest quest)
        {
            List<string> paths = quest.getPaths();

            foreach (string file in paths)
            {
                AntivirusLibrary.FileManipulation.FileManipulationIgnor(file);
                var monitoringObject = GetMonitoringObject(file);
                if (monitoringObject != null)
                {
                    monitoringObject.StopMonitoring();
                    AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "Monitoring");
                }

                AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "Quarantine");
                AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "Schedule");
            }
        }

      private  static void StartMonitoring(Quest quest)
        {
            Thread monitorThread = new Thread(MailSlotServerMethods.StartMonitoringServer);
            monitorThread.Start();
            //MailSlotServerMethods.StartMonitoringServer();
            WriteMail("Monitoring started");
        }
        public static void StartMonitoringServer()
        {
            List<string> paths = DataBaseMethods.DataBaseGetOneField("Monitoring",1);

            foreach (string file in paths)
            {
                Console.WriteLine(file);
                listMonitoring.Add(new MonitoringMethods(file));
                
                
            }
        }
        
        private static void StopMonitoring()
        {
            List<string> paths = DataBaseMethods.DataBaseGetOneField("Monitoring", 1);
            WriteMail("Monitoring stoped");
            foreach (string file in paths)
            {
                var monitoringObject = GetMonitoringObject(file);
                if (monitoringObject != null) monitoringObject.StopMonitoring();
            }

        }

      private  static bool GetScanStatus()
        {
            return ScanStatus;
        }
      private  static string GetScanProgress()
        {
            return (AntivirusLibrary.ScanMethods.EndScan / FilesForScanCount * 100) + "%";
        }

        private static MonitoringMethods GetMonitoringObject(string path)
        {
            for (int i=0; i<listMonitoring.Count; i++)
            {
                if (listMonitoring[i].path.Equals(path)) return listMonitoring[i];
            }
            return null;
        }
      public  static void CreateServerMailslot()
        {
            string path = "\\\\.\\mailslot\\mailServer";
            handleS = CreateMailslot(path, 0, uint.MaxValue, IntPtr.Zero);
            Console.WriteLine("ServerMailPath: " + path);


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
      private  static string ReadMail()
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
                            return Encoding.UTF8.GetString(buffer).Replace("\0", "");
                        }
                    }
                }
            }
            return "";
        }

      public  static void WriteMail(string text)
        {
            CreateClientConnection();
            if (!handleC.Equals(new IntPtr(-1)))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);

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
        public int command;
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
            Console.WriteLine("Show path " + path);
            paths.Add(path);
        }
        public void setOptions(string option)
        {
            options.Add(option);
        }
        public List<string> getPaths()
        {
            return paths;
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
