using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace AntivirusLibrary
{
    public static class DirectoryAndFileMethods
    {
        public static List<String> FilesForScan(List<String> files)
        {
            List<String> filesForScan = new List<string>();
            foreach (string file in files)
            {
                string a = GetFileType(file);
                if (a.Equals("pe")) filesForScan.Add(file);
            }
            return filesForScan;
        }
       public static void CheckAllFiles(List<String> files)
        {
            foreach (string file in files)
            {
                GetFileType(file);
            }
        }

       public static List<String> GetAllFiles(string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
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
            else
            {
                List<string> files = new List<string>();
                if (GetFileType(path).Equals("zip")) //если находим архив
                {
                    files.AddRange(GetFilesFromZip(path)); //добавляем в лист нужные файлы из архива
                }
                else files.Add(path);
                return files;
                
            }
            
        }
       public static List<String> GetFilesFromZip(string zipPath)
        {

            string tempDir = "D:\\CheckZipFiles";
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir); //создаем директорию для файлов из архивов
            else
            {
                string directoria = "D:\\CheckZipFiles";
                Directory.Delete(directoria, true);
                Directory.CreateDirectory(tempDir);
            }
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
       public static string GetFileType(string file)
        {
            string fileType = "";
            if (!File.Exists(file)) return "";
            try
            {
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var buffer = new byte[10];
                    fs.Read(buffer, 0, buffer.Length);
                    var signature = string.Join(" ", buffer.Select(b => b.ToString("X2")));

                    if (signature.StartsWith("4D 5A"))
                    {
                        fileType = "pe";
                    }

                    if (signature.StartsWith("50 4B 03 04"))
                    {
                        fileType = "zip";
                    }
                }
                return fileType;
            }
            catch(Exception e)
            {
                return "";
            }
          
        }
        
    }
}
