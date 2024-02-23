using OpenQA.Selenium;
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
            var elements = WebDriver.FindElements(By.XPath(xPath));
            return elements.Count > 0;
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

        public void ClickById(string xPath)
        {
            WebDriver.FindElement(By.Id(xPath)).Click();
        }

        public void ClickByXPath(string xPath)
        {
            WebDriver.FindElement(By.XPath(xPath)).Click();
        }

        public void Contains(string xPath, string value)
        {
            Assert.That(WebDriver.FindElement(By.XPath(xPath)).Text.Contains(value), Is.True);
        }

        public void Equals(string xPath, string value)
        {
            Assert.That(WebDriver.FindElement(By.XPath(xPath)).Text.Equals(value), Is.True);
        }

        #endregion

        #region Métodos de atribuição

        public static string GenerateNome()
        {
            var random = new Random();
            var nomes = new string[] { "Nome A", "Nome B", "Nome C", "Nome D", "Nome E" };
            var sobrenomes = new string[] { "Sobrenome A", "Sobrenome B", "Sobrenome C", "Sobrenome D", "Sobrenome E", "Sobrenome F" };
            return $"{nomes[random.Next(nomes.Length)]} {sobrenomes[random.Next(sobrenomes.Length)]}";
        }

        #endregion
    }
}
