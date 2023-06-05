using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace POM
{
    public class BasePage
    {
        public static IWebDriver driver = null;


        #region Browsers 
        public IWebDriver chromeOpen()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        
        public IWebDriver firefoxOpen()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        
        public IWebDriver edgeOpen()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        public void driverClose()
        {
            driver.Close();
        }
        
        public void driverQuit()
        {
            driver.Quit();
        }

        public void maximizeBrowser()
        {
            driver.Manage().Window.Maximize();

        }

        public void minimizeBrowser()
        {
            driver.Manage().Window.Minimize();

        }
        #endregion

        #region web elements methods

        #region public methods

        public void Element(By by)
        {
            driver.FindElement(by);
        }

        public void Write(By locator, string value)
        {

            driver.FindElement(locator).SendKeys(value);

        }

        public void Click(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public void Clear(By locator)
        {
            driver.FindElement(locator).Clear();
        }

        public void GoToURL(string url)
        {
            driver.Url = url;
        }

        public string GetElementText(By locator)
        {
            string text;
            try
            {
                text = driver.FindElement(locator).Text;
            }
            catch
            {
                try
                {
                    text = driver.FindElement(locator).GetAttribute("value");
                }
                catch 
                {
                    text = driver.FindElement(locator).GetAttribute("innerHTML");
                }
            }

            return text;
        }
        
        public string GetElementState(By locator)
        {
            string elementState = driver.FindElement(locator).GetAttribute("Disabled");
            
            if (elementState == null)
            {
                elementState = "enabled";
            }
            else if (elementState == "true")
            {
                elementState = "disabled";
            }

            return elementState;
        }

        public void PlaybackWait(int  milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public static string ExecuteJSCode(string jsCode)
        {
            string value = null;

            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                value = (string)js.ExecuteScript(jsCode);
            }

            catch (Exception)
            {

            }

            return value;
        }
        #endregion public

        #region private methods

        private bool IsElementTxtField(By locators)
        {
            try
            {
                bool resultText = Convert.ToBoolean(driver.FindElement(locators).GetAttribute("type").Equals("text"));

                bool resultPassword = Convert.ToBoolean(driver.FindElement(locators).GetAttribute("type").Equals("password")); 
                
                if (resultText == true || resultPassword == true) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch
            {
                return false;
            }
        }


        
        // is page ready, visible, clickable methods to be written here
        
        private bool IsPageReady(IWebDriver driver)
        {
            return ((IJavaScriptExecutor)driver)
                .ExecuteScript("return document.readystate").Equals("complete");
        }
        
        private bool IsElementVisible(By by)
        {
            if (driver.FindElement(by).Displayed || driver.FindElement(by).Enabled)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public bool IsElementClickable(By by)
        {
            if (driver.FindElement(by).Displayed && driver.FindElement(by).Enabled)
            {

                return true;
            }
            else
            { 
                return false; 
            }
        }
     
        private IWebElement WaitForElement(By locators, int waitTimeforElement = 0)
        {
            IWebElement element = null;

            try
            {
                if(waitTimeforElement != 0 && waitTimeforElement.ToString() != null)
                {
                    PlaybackWait(waitTimeforElement * 1000);
                }

                element = driver.FindElement(locators);
            }

            catch 
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(driver => IsPageReady(driver) == true && IsElementVisible(locators) == true && IsElementClickable(locators) == true);

                element = driver.FindElement(locators);
            }

            return element;
        }

        #endregion
        
        #endregion
    }
}
