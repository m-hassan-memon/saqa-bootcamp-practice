using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace POM
{
    public class BasePage
    {
        public static IWebDriver driver;
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath = "C:\\ExtentReports\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "\\";


        public static void LogReport(string testcase)
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            #region ABC
            htmlReporter.Config.DocumentTitle = "Automation Testing Report";
            //htmlReporter.Config.ReportName = "SQA 9 Bootcamp " + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            htmlReporter.Config.Theme = Theme.Standard;

            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);

            extentReports.AddSystemInfo("AUT", "Hotel Adactin");
            extentReports.AddSystemInfo("Environment", "QA");
            extentReports.AddSystemInfo("Machine", Environment.MachineName);
            extentReports.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            #endregion
        }
        public void NodeCreation(string methodname)
        {
            exChildTest = exParentTest.CreateNode(methodname);
        }
        public static void TakeScreenshot(Status status, string stepDetail)
        {
            string path = dirpath + "TestExcelLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            BasePage.exChildTest.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path + ".png").Build());
        }
        public static void ExtentFlush()
        {
            extentReports.Flush();
        }
        public void InitializeChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
        public void EnterText(By by, string value)
        {
            try
            {
                driver.FindElement(by).SendKeys(value);
                TakeScreenshot(Status.Pass, "Text Written on " + by + " this locator and value : " + value);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Enter Text Failed : " + ex.ToString());
            }

        }

        public void MoveToNewWindow(int i)
        {
            var handlers = driver.WindowHandles;

            driver.SwitchTo().Window(handlers[i]);
        }

        public void MoveToNewTab(int i)
        {
            var handlers = driver.WindowHandles;

            driver.SwitchTo().Window(handlers[i]);
        }

        public void DropDownTXT(By locator, string text)
        {
            var select = driver.FindElement(locator);
            var dropDown = new SelectElement(select);

            dropDown.SelectByText(text);
        }
        
        public void DropDownValue(By locator, string value)
        {
            var select = driver.FindElement(locator);
            var dropDown = new SelectElement(select);

            dropDown.SelectByValue(value);
        }
        public void DropDownIndex(By locator, int i)
        {
            var select = driver.FindElement(locator);
            var dropDown = new SelectElement(select);

            dropDown.SelectByIndex(i);
        }

        public void Clear(By by)
        {
            driver.FindElement(by).Clear();
        }
        public void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(Status.Pass, "Click on " + by);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Click Failed : " + ex.ToString());
            }
        }
        public void OpenUrl(string url)
        {
            try
            {
                driver.Url = url;
                TakeScreenshot(Status.Pass, "URL Open");
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "This Site can't be reached");
            }
        }
        public string GetElementText(By by)
        {
            string text;
            try
            {
                text = driver.FindElement(by).Text;
            }
            catch
            {
                try
                {
                    text = driver.FindElement(by).GetAttribute("value");
                }
                catch
                {
                    text = driver.FindElement(by).GetAttribute("innerHTML");
                }
            }
            return text;
        }
        public string GetElementState(By by)
        {
            string elementState = driver.FindElement(by).GetAttribute("Disabled");

            if (elementState == null)
            {
                elementState = "enabled";
            }
            else if (elementState == "false")
            {
                elementState = "enabled";
            }
            else if (elementState == "true")
            {
                elementState = "disabled";
            }
            return elementState;
        }
        public static string ExecuteJavaScriptCode(string javascriptCode)
        {
            string value = null;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                value = (string)js.ExecuteScript(javascriptCode);
            }
            catch (Exception)
            {

            }
            return value;
        }
        public static void ThreadSleepWait(int seconds)
        {
            //Mili Seconds = 

            Thread.Sleep(seconds * 1000);
        }
        public void QuitChrome()
        {
            driver.Quit();
        }

        //Capture Screenshot
        //Click using JS
        //Enter Test using JS
        //Implicit Wait
        //Scroll Down
        //Scroll Up
        //Scroll to Element
        //Drop Down 
        //Radio Button
        //Check Box (if disabled/enabled)
        //iframes
        //IAlerts (All 3 Types)
        //Window Handle (New Window, New Tab)
        //Assertion (Maximum)
        //Read CSV
        //Read XML
        //Multiple Browsers
        //Browser Options

        //To-Do (Monday)
        //Report (Extent)
        //Log
        //
    }
}
