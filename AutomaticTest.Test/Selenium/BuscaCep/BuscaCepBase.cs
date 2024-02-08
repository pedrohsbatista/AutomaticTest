using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace AutomaticTest.Test.Selenium.BuscaCep
{
    public class BuscaCepBase
    {
        protected IWebDriver WebDriver;
        protected bool Quit = true;

        [SetUp]
        public void Start()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void Finish()
        {
            if (!Quit)
                return;

            WebDriver.Quit();
        }
    }
}
