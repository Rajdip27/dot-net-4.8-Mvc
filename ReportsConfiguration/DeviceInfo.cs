using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMvcProject.Reports
{
    public class DeviceInfo
    {
        public string OutputFormat { get; set; }
        public DeviceInfo(string outputFormat = "PDF")
        {
            OutputFormat = outputFormat;
        }
        public string Landscape()
        {
            var infoModel = new
            {
                OutputFormat = OutputFormat,
                PageWidth = "11in",
                PageHeight = "8.5in",
                MarginTop = "0.5in",
                MarginLeft = "0.5in",
                MarginRight = "0.5in",
                MarginBottom = "0.5in"
            };
            return Custom(infoModel);
        }

        public string Potrait()
        {
            var infoModel = new
            {
                OutputFormat = OutputFormat,
                PageWidth = "8.5in",
                PageHeight = "11in",
                MarginTop = ".25in",
                MarginLeft = ".5in",
                MarginRight = ".5in",
                MarginBottom = ".25in"
            };
            return Custom(infoModel);
        }

        public string Legal()
        {
            var infoModel = new
            {
                OutputFormat = OutputFormat,
                PageWidth = "14in",
                PageHeight = "8.5in",
                MarginTop = "0.5in",
                MarginLeft = ".5in",
                MarginRight = ".5in",
                MarginBottom = "0.5in"
            };
            return Custom(infoModel);
        }

        public string Custom(dynamic infoModel)
        {
            return "<DeviceInfo>  <OutputFormat>" + OutputFormat + "</OutputFormat>  <PageWidth>" + infoModel.PageWidth + "</PageWidth>  <PageHeight>" + infoModel.PageHeight + "</PageHeight>  <MarginTop>" + infoModel.MarginTop + "</MarginTop>  <MarginLeft>" + infoModel.MarginLeft + "</MarginLeft>  <MarginRight>" + infoModel.MarginRight + "</MarginRight>  <MarginBottom>" + infoModel.MarginBottom + "</MarginBottom></DeviceInfo>";
        }
    }
}