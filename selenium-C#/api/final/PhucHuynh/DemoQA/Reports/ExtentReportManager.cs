using System.Reflection;
using System.IO;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Utils;
using AventStack.ExtentReports.Reporter;

namespace DemoQA.Reports
{
    public class ExtentReportManager
    {
        private static readonly Lazy<ExtentReports> _lazyReport = new Lazy<ExtentReports>(() => new ExtentReports());
        public static  ExtentReports Instance {get{return _lazyReport.Value;}}
        static ExtentReportManager()
        {
            //Get Repot Path
            string projectPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string reportPath = Path.Combine(projectPath, "TestResults");
            if (!(Directory.Exists(reportPath)))
            {
                Directory.CreateDirectory(reportPath);

            }
            //Config html reporter
            var htmlReporter = new ExtentHtmlReporter(reportPath +@"\index.html");
            htmlReporter.LoadConfig(projectPath +@"\ExtentReportConfig.xml");
            Instance.AttachReporter(htmlReporter);    
        }
        public static void GenerateReport()
        {
            Instance.Flush();
        }
    }
}