using OpenQA.Selenium.Chrome;

namespace AutomaticTest.Test.Selenium.BuscaCep.Core
{
    public static class ChromeOptionsHelper
    {
        public static ChromeOptions GetChromeOptions(bool headlessMode)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(headlessMode ? GetHeadlessMode() : GetDevMode());
            return chromeOptions;            
        }

        private static string[] GetHeadlessMode()
        {
           return new string[] { "window-size=1366x768", "disk-cache-size=0", "headless"};
        }

        private static string[] GetDevMode()
        {
            return new string[] { "disk-cache-size=0", "start-maximized" };     
        }
    }
}
