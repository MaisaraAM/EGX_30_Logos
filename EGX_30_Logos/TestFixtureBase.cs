using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriver.Utilities;

namespace EGX_30_Logos
{
    public class TestFixtureBase
    {
        public IWebDriver _webdriver;

        WebDriverFactory webdriverFactory = new WebDriverFactory();
        WebDriverActions webdriverActions;

        public void OpenBrowser(string Url)
        {
            _webdriver = webdriverFactory.InitializeDriver(Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            webdriverFactory.CloseBrowser(_webdriver);
        }
    }
}
