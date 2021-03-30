using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntivirusLibrary
{
    public class DataReportMonitoring
    {
        public string path;
        public string virusType;
        public string date;
        public string time;
        public string operation;

        public DataReportMonitoring(string str)
        {
            path = str.Split('?')[1];
            virusType = str.Split('?')[5];
            date = str.Split('?')[2];
            time = str.Split('?')[3];
            operation = str.Split('?')[4];
        }
    }
}
