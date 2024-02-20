using OpenQA.Selenium;

namespace AutomaticTest.Test.Selenium
{
    public class Settings
    {
        protected IWebDriver WebDriver;
        //Desativado agora olha para propriedade HeadlessMode para verificar se fecha ou não o navegador
        //protected bool Quit = true;
        protected bool HeadlessMode = false;
    }
}
