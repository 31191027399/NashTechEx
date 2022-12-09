using System.IO;
using System;
using DemoQASpecFlow.Pages;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using System.Threading;
using OpenQA.Selenium;
using DemoQASpecFlow.Library;
using NUnit.Framework.Interfaces;

namespace DemoQASpecFlow
{
    [Binding]
    public static class Context
    {
        public static ExtentReports Extent;
        public static IConfiguration Config;
        public static ThreadLocal<IWebDriver> ThreadLocalWebDriver = new ThreadLocal<IWebDriver>();
        public static ExtentTest Test;
        public static ExtentTest Node;
        const string AppSettingPath = "Configurations\\appsettings.json";

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            TestContext.Progress.WriteLine("=========>Global OneTimeSetUp");

            //Read Configuration file
            Config = ConfigurationHelper.ReadConfiguration(AppSettingPath);

            //Init Extend report
            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var actualPath = dir.Substring(0, dir.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            var reportPath = projectPath + ConfigurationHelper.GetConfigurationByKey("TestResult.FilePath");

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
            Extent.AddSystemInfo("Application under Test", "Assest Management");
            Extent.AddSystemInfo("Function under Test", "Login");
            Extent.AddSystemInfo("Version", "1.0");
            Extent.AddSystemInfo("Environment", "Test Environment");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            TestContext.Progress.WriteLine("=========>Global OneTimeTearDown");
            GetWebDriver().Quit();
            
            ThreadLocalWebDriver.Dispose();
            Extent.Flush();
        }
        [BeforeFeature]
        public static void CreateTestForExtendReport()
        {
            Test = Extent.CreateTest(TestContext.CurrentContext.Test.ClassName);
        }
        public static IWebDriver GetWebDriver()
        {
            return ThreadLocalWebDriver.Value;
        }
        [BeforeScenario]
        public static void BeforeScenario()
        {
            ThreadLocalWebDriver.Value = BrowserFactory.InitDriver((ConfigurationHelper.GetConfigurationByKey("Browser")));
            GetWebDriver().Manage().Window.Maximize();
            Node = Test.CreateNode(TestContext.CurrentContext.Test.Name);
            Console.WriteLine("BaseTest Set up");
        }
        [AfterScenario]
        public static void AfterScenario()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    var fileLocation = ScreenshotHelper.CaptureScreenshot(GetWebDriver(), TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
                    var mediaEntity = ScreenshotHelper.CaptureScreenShotAndAttachToExtendReport(GetWebDriver(), TestContext.CurrentContext.Test.Name);
                    Node.Fail("#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus + stacktrace, mediaEntity);
                    Node.Fail("#Screenshot Below: " + Node.AddScreenCaptureFromPath(fileLocation));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    Node.Log(logstatus, "#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus);
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    Node.Skip("#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus);
                    break;
                default:
                    logstatus = Status.Pass;
                    Node.Log(logstatus, "#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus);
                    break;
            }
            GetWebDriver().Quit();
            GetWebDriver().Dispose();
            Console.WriteLine("BaseTest Tear Down");
        }


    }
}