using OpenQA.Selenium.Chrome;

namespace AutomaticTest.Test.Selenium.AutomaticTestWeb.Core
{
    public class Base : DSL
    {
        [SetUp]
        public void Start()
        {
            WebDriver = new ChromeDriver(ChromeOptionsHelper.GetChromeOptions(HeadlessMode));
            WebDriver.Navigate().GoToUrl("http://localhost:3000/clientes");
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
