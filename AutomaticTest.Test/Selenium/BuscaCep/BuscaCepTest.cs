using OpenQA.Selenium;

namespace AutomaticTest.Test.Selenium.BuscaCep
{
    public class BuscaCepTest : BuscaCepBase
    {
        [Test]
        public void BuscarCep()
        {
            WebDriver.FindElement(By.Id("endereco")).SendKeys("15085-350");
            WebDriver.FindElement(By.Id("btn_pesquisar")).Click();
            Assert.That(WebDriver.FindElement(By.XPath("//*[@id=\"resultado-DNEC\"]/tbody/tr/td[1]")).Text.Equals("Avenida José Munia - até 5801 - lado ímpar"), Is.True);
            Quit = false;
        }
    }
}
