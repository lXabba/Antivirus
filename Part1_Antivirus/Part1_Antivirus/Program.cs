using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Part1_Antivirus
{
    class Program
    {
        static void Main(string[] args)
        {

            List<String> files = FilesForScan(GetAllFilesForScan("D:\\3 семестр\\Низкоуровневое\\Антивирус\\Test"));
            PrintList(files);
            Console.Read();
        }
        static List<String> FilesForScan(List<String> files)
        {
            List<String> filesForScan = new List<string>();
            foreach (string file in files)
            {
                string a = GetFileType(file);
                if (a.Equals("pe")) filesForScan.Add(file);
            }
            return filesForScan;
        }
        static void CheckAllFiles(List<String> files)
        {
            foreach (string file in files)
            {
                GetFileType(file);
            }
        }

        static List<String> GetAllFilesForScan(string path)
        {
            List<String> allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList<String>(); //получаем все файлы
            List<String> temp = new List<string>(); //делаем временный лист, куда добавляем файл из архивов
            foreach (string file in allFiles) //идет по всем файлам чтобы найти архив
            {
                if (GetFileType(file).Equals("zip")) //если находим архив
                {
                    temp.AddRange(GetFilesFromZip(file)); //добавляем в лист нужные файлы из архива
                }
            }
            allFiles.AddRange(temp); //добавляем в основной лист файлы из архивов
            return allFiles; //выходим
        }
        static List<String> GetFilesFromZip(string zipPath)
        {
            
            string tempDir = "CheckZipFiles";
            if (!Directory.Exists(tempDir))
            Directory.CreateDirectory(tempDir); //создаем директорию для файлов из архивов
           
            ZipFile.ExtractToDirectory(zipPath, tempDir); //разархивируем файлы в директорию
            List<String> allFiles = Directory.GetFiles(tempDir, "*.*", SearchOption.AllDirectories).ToList<String>();
            foreach (string file in allFiles) //идет по всем файлам чтобы найти архив
            {
                if (GetFileType(file).Equals("zip")) //если находим архив
                {
                    ZipFile.ExtractToDirectory(file, tempDir);

                }
            }

            return Directory.GetFiles(tempDir, "*.*", SearchOption.AllDirectories).ToList<String>();

        }
        static string GetFileType(string file)
        {
            string fileType = "";
            using (var fs = new FileStream(file, FileMode.Open))
            {
                var buffer = new byte[10];
                fs.Read(buffer, 0, buffer.Length);
                var signature = string.Join(" ", buffer.Select(b => b.ToString("X2")));

                if (signature.StartsWith("4D 5A")) { 
                    //Console.WriteLine(file + " type: PE");
                    fileType = "pe";
                }

                if (signature.StartsWith("50 4B 03 04"))
                {
                    //Console.WriteLine(file + " type: ZIP");
                    fileType = "zip";
                }
            }
            return fileType;
        }
        static void PrintList(List<String> strings)
        {
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }
        }

    }
}
