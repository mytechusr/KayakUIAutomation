using KayakUIAutomation.Base;
using OpenQA.Selenium;

namespace KayakUIAutomation.Helpers
{
    public class ExtensionHelper
    {
        public static void ExecuteJs(string script, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            js.ExecuteScript(script, element);
        }
    }
}
