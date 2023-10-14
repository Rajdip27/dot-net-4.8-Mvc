using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMvcProject.Reports;

namespace WebAppMvcProject.ReportsConfiguration
{
    public class ReportResult :ActionResult, IReportResult
    {
        private byte[] ByteArray { get; set; }

        private ReportConfig Config { get; set; }

        private ReportDataSource ReportDataSource { get; set; }

        public string MimeType { get; set; }

        public string FileExtention { get; set; }

        public ReportResult(ReportConfig config, List<ReportDataSource> reportDataSource)
        {
            Config = config;
            if (!File.Exists(config.ReportFilePath))
            {
                throw new FileNotFoundException("report path not found.");
            }

            LocalReport localReport = new LocalReport
            {
                ReportPath = config.ReportFilePath
            };
            foreach (ReportDataSource item in reportDataSource)
            {
                localReport.DataSources.Add(item);
            }

            ByteArray = localReport.Render(Config.ReportType, Config.DeviceInfo, out var mimeType, out var _, out var fileNameExtension, out var _, out var _);
            MimeType = mimeType;
            FileExtention = fileNameExtension;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.Clear();
            if (Config.IsDownloadable)
            {
                response.AddHeader("content-disposition", "attachment; filename=" + Config.FileName + "." + Config.ReportType);
            }

            response.ContentType = MimeType;
            response.BinaryWrite(ByteArray);
        }
    }
}