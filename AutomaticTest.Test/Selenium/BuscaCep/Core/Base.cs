using OpenQA.Selenium.Chrome;

namespace AutomaticTest.Test.Selenium.BuscaCep.Core
{
    public class Base : DSL
    {
        [SetUp]
        public void Start()
        {
            WebDriver = new ChromeDriver(ChromeOptionsHelper.GetChromeOptions(HeadlessMode));
            WebDriver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            // Desativado agora está declarado no ChromeOptions
            // WebDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Finish()
        {
            if (!HeadlessMode)
                return;

            WebDriver.Quit();
        }
    }
}
