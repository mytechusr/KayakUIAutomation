using KayakUIAutomation.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace KayakUIAutomation.Helpers
{
    public class WaitHelper
    {
        public static void WaitForElementVisibility(By locator, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementInVisibility(By locator, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void WaitForElementToBeClickable(IWebElement element, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForTextToBePresent(IWebElement element, string text, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }
        public static bool IsElementPresent(By locator)
        {
            try
            {
                return DriverContext.Driver.FindElements(locator).Count > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void WaitImplicitly(int timeoutInSeconds = 2)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(timeoutInSeconds));
        }

        public static void WaitForPageToLoad()
        {
            WaitHelper.WaitForElementVisibility(By.CssSelector(".zEiP-pres-default"), TimeSpan.FromSeconds(20));
        }

    }
}
