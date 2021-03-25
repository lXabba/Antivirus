using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4_Antivirus
{
    class ScanFile
    {
        // 6DAC
        void Scan(byte[] byteArray)
        {
            for(int i=0; i<byteArray.Length-4; i++)
            {
                string temp = ByteToString(byteArray,i,4);
                List<string> listResults = new List<string>();  //zapros
                foreach(string str in listResults)
                {
                    temp = ByteToString(byteArray, i, str.Length);
                    if (temp.Equals(str)) return; //выход это вирус уиии

                }
            }
            return; //это не вирус =(
        }

        string ByteToString(byte[] byteArray, int index, int length)
        {
            string result = BitConverter.ToString(byteArray,index, length).Replace("-","");
            return result;   
        }
    }
}
