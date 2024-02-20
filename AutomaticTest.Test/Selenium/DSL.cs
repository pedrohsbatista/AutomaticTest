﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomaticTest.Test.Selenium
{
    public class DSL : Settings
    {
        #region Métodos de manipulação

        public static void Wait(int milliseconds) => Thread.Sleep(milliseconds);

        public void Clear(string xPath) => WebDriver.FindElement(By.XPath(xPath)).Clear();

        public void ClickOut() => WebDriver.FindElement(By.XPath("//html")).Click();

        public void WaitElement(string xPath, int milliseconds)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(milliseconds));
            wait.Until(x => { return x.FindElement(By.XPath(xPath)); });
        }

        public void WaitElementGone(string xPath, int milliseconds)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(milliseconds));
            wait.Until(x => x.FindElements(By.XPath(xPath)).Count == 0);
        }

        public bool ExistElement(string xPath)
        {
            try
            {
                WebDriver.FindElement(By.XPath(xPath));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        #endregion

        #region Métodos de interação
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

        #endregion

        #region Métodos de atribuição

        #endregion
    }
}
