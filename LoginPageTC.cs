using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM
{
    [TestClass]
    public class LoginPageTC : Execution
    {
        LoginPage loginPage = new LoginPage();

        [TestMethod]
        [Owner("Aun Hashmi")]
        [Description("")]
        public void LoginWithValidUserValidPassword()
        {
            loginPage.username = "AmirTester";
            loginPage.password = "AmirTester";

            loginPage.Login();
        }
        [TestMethod]
        public void LoginWithValidUserInValidPassword()
        {
            loginPage.username = "AmirTester";
            loginPage.password = "AmirTester123";

            loginPage.Login();
        }

        [TestMethod]
        public void LoginWithEmptyUserEmptyPassword()
        {
            //loginPage.username = null;
            //loginPage.password = null;

            loginPage.Login();
            Assert.AreNotEqual("Enter UserName", driver.FindElement(By.Id("username_span")).Text);
        }
    }
}