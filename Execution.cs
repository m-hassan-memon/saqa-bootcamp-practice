using System;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POM
{
    [TestClass]
    public class Execution : Login
    {
        [TestMethod]
        [TestCategory("EmptyLogin")]
        public void EmptyLogin()
        {

            chromeOpen();
            GoToURL("https://adactinhotelapp.com/");
            SignIn("", "");


        }


    }
}
