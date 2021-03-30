using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AntivirusLibrary
{
    public class MonitoringMethods
    {
        FileSystemWatcher watcher;
        public string path;
        public MonitoringMethods(String path)
        {
            this.path = path;
            watcher = new FileSystemWatcher(path);

            watcher.NotifyFilter = NotifyFilters.LastWrite;

            watcher.Changed += OnChanged;
            


            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
           
        }
        public void StopMonitoring()
        {
            watcher.Changed -= OnChanged;
        }
        
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
            if (DirectoryAndFileMethods.GetFileType(e.FullPath).Equals("pe"))
            {
                List<string> signatures = AntivirusLibrary.DataBaseMethods.DataBaseGetOneField("Signatures", 1);
                ScanMethods.Scan(ScanMethods.GetScanBuffer(e.FullPath), signatures,e.FullPath ,path);
            }
            
        }


    }
}
