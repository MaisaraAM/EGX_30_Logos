using EGX_30_Logos.Pages;
using NUnit.Framework;
using System;

namespace EGX_30_Logos
{
    [TestFixture]
    public class GetEGX30Logos : TestFixtureBase
    {
        static string Url = "";

        [Test]
        public void getEGX30Logos()
        {
            Url = "https://www.tradingview.com/symbols/EGX-EGX30/components/";
            OpenBrowser(Url);

            EGX30IndexPage eGX30IndexPage = new EGX30IndexPage(_webdriver);

            eGX30IndexPage.getLogos();
        }
    }
}
