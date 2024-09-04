using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using WebDriver.Utilities;
using By = WebDriver.Utilities.ElementFactory.by;
using System.Threading;
using System.Net;

namespace EGX_30_Logos.Pages
{
    public class EGX30IndexPage : TestFixtureBase
    {
        private IWebDriver _webdriver;
        WebUIActions webUIActions;
        WebWaits webWaits;

        WebUIElement homeIcon = new WebUIElement(By.CssSelector, ".tv-header__area--logo-menu > span > a > span.tv-header__icon > svg");
        WebUIElement stockButtonList = new WebUIElement(By.CssSelector, "table > tbody > tr > td > span > a");
        WebUIElement logoIcon = new WebUIElement(By.CssSelector, ".medium-xoKMfU7r");

        public EGX30IndexPage(IWebDriver webdriver)
        {
            this._webdriver = webdriver;
            webUIActions = new WebUIActions(webdriver);
            webWaits = new WebWaits(webdriver);
        }

        public void openStockPage()
        {
            List<string> stocks = new List<string>();
            stocks = webUIActions.getGridColumnValues(stockButtonList);
            int stockCount = stocks.Count;

            for (int i = 1; i <= stockCount; i++)
            {
                WebUIElement stockButton = new WebUIElement(By.CssSelector, "table > tbody > tr:nth-child(" + i + ") > td > span > a");

                webUIActions.moveToElementAndClick(stockButton);

                _webdriver.SwitchTo().Window(_webdriver.WindowHandles[1]);
                
                downloadLogo();

                _webdriver.Close();
                _webdriver.SwitchTo().Window(_webdriver.WindowHandles[0]);
            }
        }

        public void downloadLogo()
        {
            webWaits.WaitTillToUIElementPresent(homeIcon);
            webWaits.WaitTillToUIElementPresent(logoIcon);

            string logoURL = _webdriver.FindElement(OpenQA.Selenium.By.CssSelector(".medium-xoKMfU7r")).GetAttribute("src");
            string logoName = _webdriver.FindElement(OpenQA.Selenium.By.CssSelector(".medium-xoKMfU7r")).GetAttribute("alt");

            WebClient myWebClient = new WebClient();

            myWebClient.DownloadFile(logoURL, @"C:\Logos\" + logoName + ".svg");
        }

        public void getLogos()
        {
            webWaits.WaitTillToUIElementPresent(homeIcon);

            openStockPage();
        }
    }
}
