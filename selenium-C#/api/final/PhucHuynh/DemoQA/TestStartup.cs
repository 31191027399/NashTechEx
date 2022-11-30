using NUnit.Framework;
using DemoQA.Library;
using DemoQA.Reports;

namespace DemoQA
{
    [SetUpFixture]
    public class TestStartup
    {
[OneTimeTearDown]
public void End()
{
    //ExportHtml report
    ExtentReportManager.GenerateReport();
}

    }
}