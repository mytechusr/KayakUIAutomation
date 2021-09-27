using KayakUIAutomation.Base;
using System;
using System.Configuration;

namespace KayakUIAutomation.Config
{
    public class ConfigReader
    {

        public static string Url = ConfigurationManager.AppSettings["Url"].ToString();
        public static string strBrowser = ConfigurationManager.AppSettings["Browser"].ToString();

        public static BrowserType browser = (BrowserType)Enum.Parse(typeof(BrowserType), strBrowser);
    }
}
