using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntivirusLibrary
{
    public class DataReport
    {
        public string path;
        public string virusType;
        public string date;
        public string time;
       
        public DataReport(string str)
        {
            path = str.Split('?')[1];
            virusType = str.Split('?')[2];
            date = str.Split('?')[3];
            time = str.Split('?')[4];
        }
    }
}
