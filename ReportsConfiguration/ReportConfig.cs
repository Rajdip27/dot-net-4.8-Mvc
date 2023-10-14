using System;
using System.Data;

namespace WebAppMvcProject.Reports
{
    public class ReportConfig
    {
        public string FileName { get;set; }
        public DataTable DataTable { get; set; }
        public string ReportFilePath { get; set; }
        public string ReportSourceName { get; set; }
        public string ReportType { get; set; } = "pdf";
        public string DeviceInfo { get;set; }
        public string PageType { get; set; }
        public bool IsDownloadable { get; set; }
        public ReportConfig()
        {

            DeviceInfo = new DeviceInfo(ReportType).Potrait();
            FileName = $"{DateTime.UtcNow.AddHours(6.0):dMMMyyyyhhmmtt}";
        }
    }
}