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
        public void SendToQuarantine(string filename)
        {
            var fs = new FileStream(filename, FileMode.Open);
            fs.W
        }
    }
}
