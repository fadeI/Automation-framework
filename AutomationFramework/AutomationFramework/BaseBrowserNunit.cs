﻿using BrowserStack;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
namespace AutomationFramework
{

    [TestFixture]
    class BaseBrowserNunit
    {
        public BaseBrowserNunit(string profile, string environment)
        {
            this.profile = profile;
            this.environment = environment;
        }
        protected string profile;
        protected string environment;
        private Local browserStackLocal;
        protected IWebDriver driver;

        [SetUp]
        public void InitBrowserStack()
        {
            // getting caps from app.config 
            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + profile) as NameValueCollection;
            // getting setting from app.config 
            NameValueCollection settings = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;


            DesiredCapabilities capability = new DesiredCapabilities();

            foreach (string key in caps.AllKeys)
            {
                capability.SetCapability(key, caps[key]);
            }

            foreach (string key in settings.AllKeys)
            {
                capability.SetCapability(key, settings[key]);
            }
            string username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            if (String.IsNullOrEmpty(username))
            {
                username = ConfigurationManager.AppSettings.Get("user");
            }

            String accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
            if (String.IsNullOrEmpty(accesskey))
            {
                accesskey = ConfigurationManager.AppSettings.Get("key");
            }

            capability.SetCapability("browserstack.user", username);
            capability.SetCapability("browserstack.key", accesskey);

            

            driver = new RemoteWebDriver(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
            if (browserStackLocal != null)
            {
                browserStackLocal.stop();
            }

        }

    }
}
