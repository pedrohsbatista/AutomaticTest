using OpenQA.Selenium;

namespace AutomaticTest.Test.Selenium.BuscaCep.Core
{
    public class DSL : Settings
    {
        public void WriteByXPath(string xPath, string value)
        {
            WebDriver.FindElement(By.XPath(xPath)).SendKeys(value);
        }

        public void WriteById(string id, string value)
        {
            WebDriver.FindElement(By.Id(id)).SendKeys(value);
        }

        public void Click(string xPath)
        {
            WebDriver.FindElement(By.Id(xPath)).Click();
        }

        public void Contains(string xPath, string value)
        {
            Assert.That(WebDriver.FindElement(By.XPath(xPath)).Text.Equals(value), Is.True);
        }
    }
}
