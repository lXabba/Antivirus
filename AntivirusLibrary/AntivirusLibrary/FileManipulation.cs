using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AntivirusLibrary
{
    public static class FileManipulation
    {
        public static void FileManipulationQuarantine(string path)
        {
            if (!File.Exists(path)) return;
            using (var stream = File.Open(path, FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite))
            {
                stream.Position = 0;
                stream.WriteByte(0x51);
                stream.Close();
                Console.WriteLine("Q " + path);
            }
            
        }
        public static void FileManipulationRecover(string path)
        {
            if (!File.Exists(path)) return;
            using (var stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                stream.Position = 0;
                stream.WriteByte(0x4D);
                stream.Close();
                Console.WriteLine("Q " + path);
            }

        }
        public static void FileManipulationQuaratineFull(string file)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            string time = DateTime.Now.ToString("H:mm");
            AntivirusLibrary.DataBaseMethods.AddNote("QUARANTINE", "PATH,VIRUSTYPE,DATE,TIME", $"'{file}','virus','{date}','{time}'");
            using (var stream = File.Open(file, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                stream.Position = 0;
                stream.WriteByte(0x51);
                stream.Close();
                Console.WriteLine("Q " + file);
            }

        }
        public static void FileManipulationDelete(string path)
        {
            File.Delete(path);
            Console.WriteLine("delete " + path);
        }

        public static void FileManipulationDeleteFull(string file)
        {
            AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "Monitoring");
            AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "Quarantine");
            AntivirusLibrary.DataBaseMethods.DataBaseDeleteNote(file, "Schedule");
            File.Delete(file);
            Console.WriteLine("delete " + file);
        }
        public static void FileManipulationIgnor(string path)
        {
            //код для базы данных
        }
    }
}
