using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomationFramework
{
    [TestFixture("single", "chrome")]
    class Example : BaseBrowserNunit
    {

        public Example(string profile, string environment) : base(profile, environment) { }

        [Test]
        public void excute()
        {

            driver.Navigate().GoToUrl("https://www.google.com/");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("BrowserStack");
            query.Submit();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("BrowserStack - Google Search", driver.Title);

        }
    }
}
