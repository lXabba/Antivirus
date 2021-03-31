using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace AntivirusLibrary
{
   public static class ScanMethods
    {
        public static int EndScan = 0;
        
        public static string Scan(byte[] byteArray, List<string> signatureList, string filePath, string dirPath) //уточнить
        {
            for (int i = 0; i < byteArray.Length; i++)
            {
                //string temp = ByteToString(byteArray, i, 4);
                
                foreach (string str in signatureList)
                {
                    if (byteArray.Length - i - 1 >= str.Length/2)
                    {
                        string temp = ByteToString(byteArray, i, str.Length/2);
                        

                        if (temp.Equals(str)) {
                            string type = AntivirusLibrary.DataBaseMethods.DataBaseGetVirusType(str);
                            string date = DateTime.Now.ToString("MM/dd/yyyy");
                            string time = DateTime.Now.ToString("H:mm");

                            AntivirusLibrary.DataBaseMethods.AddNote("SCANREPORT", "PATH,VIRUSTYPE,DATE,TIME", $"'{filePath}','{type}','{date}','{time}'");
                            string change = DataBaseMethods.DataBaseGetOneFieldIn("Monitoring", 4, $@"PATH='{dirPath}'");
                            
                            
                            Console.WriteLine(filePath);
                            if (change.Equals("QUARANTINE"))
                            {
                                AntivirusLibrary.DataBaseMethods.AddNote("MONITORINGREPORT", "PATH,DATE,TIME,CHANGE,VIRUSTYPE", $"'{filePath}','{date}','{time}','в карантине','{type}'");
                                FileManipulation.FileManipulationQuaratineFull(filePath);
                                Console.WriteLine("SendToQuarantine");
                            }
                            else if (change.Equals("DELETE"))
                            {
                                AntivirusLibrary.DataBaseMethods.AddNote("MONITORINGREPORT", "PATH,DATE,TIME,CHANGE,VIRUSTYPE", $"'{filePath}','{date}','{time}','удален','{type}'");
                                FileManipulation.FileManipulationDeleteFull(filePath);
                                Console.WriteLine("Deleted");
                            }
                            Console.WriteLine("virus");
                            return "virus"; 
                            } //выход это вирус уиии 
                    }
                }
            }
            Console.WriteLine("clear");
            return "clear"; //это не вирус =(
        }
        public static void Scan(Object obj)
        {
            if (MailSlotServerMethods.ScanStatus == false)
            {
                Console.WriteLine("****************************");
                return;
            }
            Console.WriteLine("Start");
            object[] data = obj as object[];
            byte[] byteArray = data[0] as byte[];
            List<string> signatureList = data[1] as List<string>;
            string filePath = data[2] as string;


            for (int i = 0; i < byteArray.Length; i++)
            {
                if (MailSlotServerMethods.ScanStatus == false) {
                    Console.WriteLine("****************************");
                    return; }
                //string temp = ByteToString(byteArray, i, 4);
                
                foreach (string str in signatureList)
                {
                    if (byteArray.Length - i - 1 >= str.Length / 2)
                    {
                        string temp = ByteToString(byteArray, i, str.Length / 2);


                        if (temp.Equals(str))
                        {
                            string type = AntivirusLibrary.DataBaseMethods.DataBaseGetVirusType(str);
                            string date = DateTime.Now.ToString("MM/dd/yyyy");
                            string time = DateTime.Now.ToString("H:mm");
                            AntivirusLibrary.DataBaseMethods.AddNote("SCAN", "PATH,VIRUSTYPE,DATE,TIME", $"'{filePath}','{type}','{date}','{time}'");
                            AntivirusLibrary.DataBaseMethods.AddNote("SCANREPORT", "PATH,VIRUSTYPE,DATE,TIME", $"'{filePath}','{type}','{date}','{time}'");
                            Console.WriteLine("Virus");
                            EndScan++;
                            if (MailSlotServerMethods.FilesForScanCount == EndScan)
                            {
                                EndScan = 0;
                                MailSlotServerMethods.WriteMail("Всего просканированно " + MailSlotServerMethods.FilesForScanCount + "файлов");
                                MailSlotServerMethods.FilesForScanCount = 0;
                                MailSlotServerMethods.ScanStatus = false;
                                MailSlotServerMethods.WriteMail("Завершено");
                            }
                            MailSlotServerMethods.CreateClientConnection();
                            MailSlotServerMethods.WriteMail("Scaned " + filePath);
                            int b = (int)((double)EndScan / MailSlotServerMethods.FilesForScanCount * 100);
                            MailSlotServerMethods.WriteMail("Выполнено " + b);
                            Console.WriteLine(MailSlotServerMethods.ScanStatus + " SCANSTATUS");
                            Console.WriteLine("End");
                            return; //DataBaseMethods.DataBaseGetVirusType(str); //выход это вирус уиии 
                        }
                    }
                }
            }
            EndScan++;
            if (MailSlotServerMethods.FilesForScanCount == EndScan)
            {
                EndScan = 0;
                MailSlotServerMethods.WriteMail("Всего просканированно " + MailSlotServerMethods.FilesForScanCount + "файлов");
                MailSlotServerMethods.FilesForScanCount = 0;
                MailSlotServerMethods.ScanStatus = false;
                MailSlotServerMethods.WriteMail("Завершено");
            }
            MailSlotServerMethods.CreateClientConnection();
            MailSlotServerMethods.WriteMail("Scaned " + filePath);
            int a = (int)((double)EndScan / MailSlotServerMethods.FilesForScanCount* 100);
            MailSlotServerMethods.WriteMail("Выполнено " + a );
           // MailSlotServerMethods.WriteMail("Выполнено " + EndScan +" M "+ MailSlotServerMethods.FilesForScanCount + "%");
            Console.WriteLine(MailSlotServerMethods.ScanStatus + " SCANSTATUS");
            Console.WriteLine("End");
            return; //это не вирус =(
        }

        public static void StopScan()
        {
            MailSlotServerMethods.ScanStatus = false;
            EndScan = 0;
            MailSlotServerMethods.FilesForScanCount = 0;
        }
        public static void ScanSchedule(Object obj)
        {
            Console.WriteLine("Start");
            object[] data = obj as object[];
            byte[] byteArray = data[0] as byte[];
            List<string> signatureList = data[1] as List<string>;
            string filePath = data[2] as string;

            for (int i = 0; i < byteArray.Length; i++)
            {
                //string temp = ByteToString(byteArray, i, 4);

                foreach (string str in signatureList)
                {
                    if (byteArray.Length - i - 1 >= str.Length / 2)
                    {
                        string temp = ByteToString(byteArray, i, str.Length / 2);


                        if (temp.Equals(str))
                        {
                            string type = AntivirusLibrary.DataBaseMethods.DataBaseGetVirusType(str);
                            string date = DateTime.Now.ToString("MM/dd/yyyy");
                            string time = DateTime.Now.ToString("H:mm");
                            //AntivirusLibrary.DataBaseMethods.AddNote("SCAN", "PATH,VIRUSTYPE,DATE,TIME", $"'{filePath}','{type}','{date}','{time}'");
                            AntivirusLibrary.DataBaseMethods.AddNote("SCHEDULEREPORT", "PATH,VIRUSTYPE,DATE,TIME", $"'{filePath}','{type}','{date}','{time}'");
                            Console.WriteLine("Virus");
                           
                            Console.WriteLine("End");
                            return; //DataBaseMethods.DataBaseGetVirusType(str); //выход это вирус уиии 
                        }
                    }
                }
            }
           
            Console.WriteLine("End");
            return; //это не вирус =(
        }

        public static void ScanToQueue(byte[] byteArray, List<string> signatureList, string filePath)
        {
            if (ThreadPool.QueueUserWorkItem(Scan, new object[] { byteArray, signatureList, filePath })) Console.WriteLine("Создан thread");
            //Scan(new object[] { byteArray, signatureList, filePath });
            //Console.WriteLine("Создан thread");
        }
        public static void ScanToQueueSchedule(byte[] byteArray, List<string> signatureList, string filePath)
        {
            if (ThreadPool.QueueUserWorkItem(ScanSchedule, new object[] { byteArray, signatureList, filePath })) Console.WriteLine("Создан thread");
            //Scan(new object[] { byteArray, signatureList, filePath });
            //Console.WriteLine("Создан thread");
        }

        private static string ByteToString(byte[] byteArray, int index, int length)
        {
            string result = BitConverter.ToString(byteArray, index, length).Replace("-", "");
            return result;
        }

        public static byte[] GetScanBuffer(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            while (true)
            {
                int nextByte = file.ReadByte();
                if ((char)nextByte == '.')
                {
                    string temp = "";
                    for (int i = 0; i < 4; i++)
                    {
                        temp += (char)file.ReadByte();
                    }
                    if (temp.Equals("text"))
                    {
                        break;
                    }
                }
                if (nextByte == -1)
                {
                    file.Close();
                    return null;
                }
            }
            file.Position += 10;

            byte[] array = new byte[4];
            file.Read(array, 0, 4);
            Array.Reverse(array, 0, array.Length);
            int rawDataSize = BitConverter.ToInt32(array, 0);

            file.Read(array, 0, 4);
            Array.Reverse(array, 0, array.Length);
            int rawDataPosition = BitConverter.ToInt32(array, 0);

            byte[] text;
            text = new byte[rawDataSize];
            file.Position = rawDataPosition;
            file.Read(text, 0, rawDataSize - 1);


            file.Close();
            return text;
        }

    }
}
