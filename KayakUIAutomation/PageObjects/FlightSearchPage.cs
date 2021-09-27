using KayakUIAutomation.Base;
using KayakUIAutomation.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace KayakUIAutomation.PageObjects
{
    class FlightSearchPage : BasePage
    {
        #region WebElements

        [FindsBy(How = How.ClassName, Using = "title-section")]
        public IWebElement lblTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'progress-bar')]/*/div[contains(@id, 'bar')]")]
        public IWebElement progressBar { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".zEiP-formField.zEiP-origin > div:nth-child(1) > div:nth-child(1) > div:nth-child(1)")]
        public IWebElement lstSource { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@placeholder='From?']")]
        public IWebElement txtSource { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".zEiP-formField.zEiP-destination")]
        public IWebElement destField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".zEiP-formField.zEiP-destination > div:nth-child(1) > div:nth-child(1) > div:nth-child(2)")]
        public IWebElement lstDest { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@placeholder='To?']")]
        public IWebElement txtDestination { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".zEiP-formField.zEiP-dates > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > span:nth-child(1) > span:nth-child(2)")]
        public IWebElement txtFromDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".zEiP-formField.zEiP-dates > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > span:nth-child(1) > span:nth-child(2)")]
        public IWebElement txtToDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='zEiP-formField zEiP-submit']")]
        public IWebElement btnSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//svg[contains(@class, 'closeIcon')]")]
        public IWebElement closeIcon { get; set; }
        #endregion

        #region Methods
        public string GetFlightsSearchPageTitle()
        {
            return lblTitle.Text.ToString();
        }

        public void EnterSource(string source)
        {
            WaitHelper.WaitForElementToBeClickable(lstSource, TimeSpan.FromSeconds(10));
            lstSource.Click();
            txtSource.SendKeys(Keys.Backspace + Keys.Backspace + source);
            txtSource.Click();
            WaitHelper.WaitForElementToBeClickable(lstSource, TimeSpan.FromSeconds(10));
            txtSource.SendKeys(Keys.Enter + Keys.Enter + Keys.Tab);
        }
        public void EnterDestination(string dest)
        {
            WaitHelper.WaitForElementToBeClickable(destField, TimeSpan.FromSeconds(10));
            lstDest.Click();
            txtDestination.SendKeys(Keys.Backspace + Keys.Backspace + dest);
            txtDestination.Click();
            WaitHelper.WaitForElementToBeClickable(lstDest, TimeSpan.FromSeconds(10));
            txtDestination.SendKeys(Keys.Enter + Keys.Enter);
        }

        public void ClearDestination()
        {
            WaitHelper.WaitForElementToBeClickable(destField, TimeSpan.FromSeconds(10));
            txtDestination.Click();
            txtDestination.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Enter);
        }

        public void EnterFromDate(string fromDate)
        {
            string script = "arguments[0].innerHTML='" + fromDate + "'";
            ExtensionHelper.ExecuteJs(script, txtFromDate);
        }

        public void EnterToDate(string toDate)
        {
            string script = "arguments[0].innerHTML='" + toDate + "'";
            ExtensionHelper.ExecuteJs(script, txtToDate);
        }

        public void ClickSearchButton()
        {
            WaitHelper.WaitForElementToBeClickable(btnSearch, TimeSpan.FromSeconds(10));
            btnSearch.Click();
        }

        public bool IsPopupDisplayed()
        {
            DriverContext.Driver.SwitchTo().ActiveElement();
            return WaitHelper.IsElementPresent(By.XPath("//*[contains(@class, 'closeIcon')]"));
        }
        #endregion
    }
}
