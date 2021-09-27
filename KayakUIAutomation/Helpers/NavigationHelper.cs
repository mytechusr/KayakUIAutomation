using KayakUIAutomation.Base;
using KayakUIAutomation.Config;

namespace KayakUIAutomation.Helpers
{
    public class NavigationHelper
    {
        public static void GoToUrl()
        {
            DriverContext.Browser.GoToUrl(ConfigReader.Url);
        }
    }
}
