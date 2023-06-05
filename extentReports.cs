using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace POM
{
    public class ExtentReport : BasePage
    {
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;


        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();
            dirpath = @"..\..\TestExecutionReports\" + '_' + testcase;

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            htmlReporter.Config.Theme = Theme.Standard;

            extentReports.AttachReporter(htmlReporter);
        }
    }
}
