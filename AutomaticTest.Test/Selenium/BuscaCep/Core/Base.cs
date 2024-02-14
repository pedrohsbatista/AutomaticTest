using OpenQA.Selenium.Chrome;

namespace AutomaticTest.Test.Selenium.BuscaCep.Core
{
    public class Base : DSL
    {

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
