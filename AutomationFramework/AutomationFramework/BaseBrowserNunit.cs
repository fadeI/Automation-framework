using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace AutomationFramework
{

    [TestFixture]
    class BaseBrowserNunit
    {

        protected string profile;
        protected string environment;

        [SetUp]
        public void InitBrowserStack()
        {
            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + profile) as NameValueCollection;
            NameValueCollection settings = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;

            
        }

    }
}
