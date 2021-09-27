using OpenQA.Selenium.Support.PageObjects;

namespace KayakUIAutomation.Base
{
    public abstract class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }
    }
}
