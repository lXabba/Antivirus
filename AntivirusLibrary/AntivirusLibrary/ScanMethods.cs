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

        public static string Scan(byte[] byteArray, List<string> signatureList) //уточнить
        {
            for (int i = 0; i < byteArray.Length; i++)
            {
                //string temp = ByteToString(byteArray, i, 4);
                
                foreach (string str in signatureList)
                {
                    if (byteArray.Length - i - 1 >= str.Length/2)
                    {
                        string temp = ByteToString(byteArray, i, str.Length/2);
                        Console.WriteLine("t" + temp+" " + str);
                   
                        if (temp.Equals(str)) return DataBaseMethods.DataBaseGetVirusType(str); //выход это вирус уиии 
                    }
                }
            }
            return "clear"; //это не вирус =(
        }
        public static void Scan(Object obj)
        {
            object[] data = obj as object[];
            byte[] byteArray = data[0] as byte[];
            List<string> signatureList = data[1] as List<string>;

            for (int i = 0; i < byteArray.Length; i++)
            {
                //string temp = ByteToString(byteArray, i, 4);

                foreach (string str in signatureList)
                {
                    if (byteArray.Length - i - 1 >= str.Length / 2)
                    {
                        string temp = ByteToString(byteArray, i, str.Length / 2);
                        Console.WriteLine("t" + temp + " " + str);

                        if (temp.Equals(str)) return; //DataBaseMethods.DataBaseGetVirusType(str); //выход это вирус уиии 
                    }
                }
            }
            return; //это не вирус =(
        }
        public static void ScanPullThreads()
        {

        }
        public static void ScanToQueue(byte[] byteArray, List<string> signatureList)
        {
            if (ThreadPool.QueueUserWorkItem(Scan, new object[] { byteArray, signatureList })) Console.WriteLine("Создан thread");
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
