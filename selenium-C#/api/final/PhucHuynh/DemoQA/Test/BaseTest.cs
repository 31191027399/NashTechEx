using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using DemoQA.Library;
using DemoQA.API;
using System.Threading;
using DemoQA.Models.Users;
using DemoQA.Services;
using System.IO;
using DemoQA.Reports;

namespace DemoQA.Test
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public abstract class BaseTest
    {
        protected APIClients _apiClient;
        public static ExtentTest Test;
        public static ExtentTest Node;
        protected UserServices _userService;
        protected Dictionary<string, UserInfoInputDto> _userInfoInput;
        protected Dictionary<string, IList<BookInfoInUserProfileInputDto>> _bookInfo;
        public BaseTest()
        {
            _apiClient = new APIClients(ConfigurationHelper.GetConfigurationByKey("TestURL"));
            _userService = new UserServices(_apiClient);
            _userInfoInput = JsonHelper.ReadAndParse<Dictionary<string, UserInfoInputDto>>(Path.GetFullPath(Path.Combine("TestData", "userInfo.json")));
            _bookInfo = JsonHelper.ReadAndParse<Dictionary<string, IList<BookInfoInUserProfileInputDto>>>(Path.GetFullPath(Path.Combine("TestData", "userBook.json")));
            ExtentTestManager.CreateParentTest(TestContext.CurrentContext.Test.ClassName);
        }
        [SetUp]
        public void BeforeTest()
        {
            
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
            UpdateTestReport();

        }
        public void UpdateTestReport()
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
                    ExtentTestManager.GetTest().Log(Status.Fail, "Message: " + TestContext.CurrentContext.Result.Message);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;

            }
            ExtentTestManager.GetTest().Log(logstatus, "Test ended with " + logstatus + stacktrace);
        }
    }
}