using KayakUIAutomation.Base;
using KayakUIAutomation.Helpers;
using OpenQA.Selenium;
using System.Linq;

namespace KayakUIAutomation.PageObjects
{
    public class FlightDetailsPage : BasePage
    {

        #region Methods
        public bool IsPriceDisplayed()
        {
            bool IsPricedisplayed;
            if (DriverContext.Driver.WindowHandles.Count > 1)
            {
                string newWindowHandle = DriverContext.Driver.WindowHandles.Last();
                var newWindow = DriverContext.Driver.SwitchTo().Window(newWindowHandle);
            }

            IsPricedisplayed = WaitHelper.IsElementPresent(By.XPath("//*[contains(@class, 'price')]"));

            return IsPricedisplayed;
        }

        #endregion
    }
}
