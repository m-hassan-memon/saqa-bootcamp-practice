using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM
{
    public partial class LoginPage
    {
        #region Locators
        By txtUsername = By.Id("username");
        By txtPassword = By.Id("password");
        By btnLogin = By.Id("login");
        #endregion
    }
}
