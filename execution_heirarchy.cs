using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace POM
{
    [TestClass]
    public class Execution : BasePage
    {
        private TestContext instance;

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            LogReport("Test Report");
            Console.WriteLine("AssemblyInitialize");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            ExtentFlush();
            Console.WriteLine("AssemblyCleanup");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("ClassInitialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("ClassCleanup");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            exParentTest = extentReports.CreateTest(TestContext.TestName);
            NodeCreation(TestContext.TestName);
            InitializeChrome();
            OpenUrl("http://adactinhotelapp.com/");
            //exChildTest = exParentTest.CreateNode(TestContext.TestName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            QuitChrome();
        }
    }
}
