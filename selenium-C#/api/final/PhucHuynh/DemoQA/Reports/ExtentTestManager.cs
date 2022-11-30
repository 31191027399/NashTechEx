using System.Runtime.CompilerServices;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AventStack.ExtentReports;

namespace DemoQA.Reports
{
    public class ExtentTestManager
    {
        private static AsyncLocal<ExtentTest> _parentTest = new AsyncLocal<ExtentTest>();
        private static AsyncLocal<ExtentTest> _childTest = new AsyncLocal<ExtentTest>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        {
            _parentTest.Value = ExtentReportManager.Instance.CreateTest(testName, description);
            return _parentTest.Value;
        }
        public static ExtentTest CreateTest(string testName, string description = null)
        {
            _childTest.Value = _parentTest.Value.CreateNode(testName, description);
            return _childTest.Value;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return _childTest.Value;
        }

    }
}