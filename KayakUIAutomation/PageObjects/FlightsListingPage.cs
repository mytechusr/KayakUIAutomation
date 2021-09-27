using KayakUIAutomation.Base;
using KayakUIAutomation.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace KayakUIAutomation.PageObjects
{
    class FlightsListingPage : BasePage
    {
        #region WebElements

        [FindsBy(How = How.XPath, Using = "//span[id ='price-text')]")]
        public IWebElement lblPrice;

        [FindsBy(How = How.CssSelector, Using = ".booking-link > span:nth-child(1)")]
        public IWebElement btnViewDeal;
        #endregion

        #region Methods
        public bool VerifySearchResultsListIsDisplayed()
        {
            bool flightsResult;
            WaitHelper.WaitForElementVisibility(By.CssSelector("div[class*='FlightResultItem']"), TimeSpan.FromSeconds(10));
            var lstFlights = DriverContext.Driver.FindElements(By.CssSelector("div[class*='FlightResultItem']"));

            flightsResult = lstFlights.Count > 0 ? true : false;

            return flightsResult;
        }

        public string VerifyPriceTextIsDisplayed()
        {
            return lblPrice.Text;
        }

        public void ClickViewDeal()
        {
            btnViewDeal.Click();
        }
        #endregion
    }
}
