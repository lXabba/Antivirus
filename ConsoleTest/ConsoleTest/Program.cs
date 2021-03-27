using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntivirusLibrary;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = AntivirusLibrary.ScanMethods.GetScanBuffer(@"D:\3 семестр\Низкоуровневое\Антивирус\Test\pe-file.exe");
            List<string> b = AntivirusLibrary.DataBaseMethods.DataBaseGetOneField("Signatures", 1);
            
            var r = AntivirusLibrary.ScanMethods.Scan(a, b);
            Console.WriteLine(r);
            Console.Read();
        }
    }
}
