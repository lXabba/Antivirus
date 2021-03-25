using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part4_Antivirus
{
    class Program
    {
        

        static void Main(string[] args)
        {
        }
        public void SendToQuarantine(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open))
            {
                stream.WriteByte(0x51);
            }
        }
        public void GetScanBuffer(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);\
            while (true)
            {
                int nextByte = file.ReadByte();
                if ((char)nextByte == '.')
                {
                    string temp = "";
                    for (int i=0; i<4; i++)
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
                    return;
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
        }

        
    }
}
