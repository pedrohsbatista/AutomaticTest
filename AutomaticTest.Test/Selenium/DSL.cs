using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V119.DeviceOrientation;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AutomaticTest.Test.Selenium
{
    public class DSL : Settings
    {
        private readonly static string[] _dominios = new string[] { "gmail.com", "outlook.com", "uol.com.br", "terra.com.br", "hostinger.com" };
        private readonly static string[] _nomes = new string[] { "Nome A", "Nome B", "Nome C", "Nome D", "Nome E" };
        private readonly static string[] _sobrenomes = new string[] { "Sobrenome A", "Sobrenome B", "Sobrenome C", "Sobrenome D", "Sobrenome E", "Sobrenome F" };
        private readonly static string[] _ddds = new string[] { "11", "12", "13", "14", "15", "16", "17", "18", "19", "21", "22", "24", "27", "28", "31", "32", "33", "34", "35", "37", "38", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "53", "54", "55", "61", "62", "64", "65", "66", "67", "68", "69", "71", "73", "74", "75", "77", "79", "81", "82", "83", "84", "85", "86", "87", "88", "89", "91", "92", "93", "94", "95", "96", "97", "98", "99" };

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
            return $"{_nomes[random.Next(_nomes.Length)]}";
        }     

        public static string GenerateSobrenome()
        {
            var random = new Random();
            return $"{_sobrenomes[random.Next(_sobrenomes.Length)]}";

        }

        public static string GenerateNomeSobrenome()
        {           
            return $"{GenerateNome()} {GenerateSobrenome()}";
        }

        public static string GenerateEmail(string endereco = null)
        {
            var random = new Random();

            if (string.IsNullOrEmpty(endereco))
                endereco = Regex.Replace($"{GenerateNome()}.{GenerateSobrenome()}", @"\s", "").ToLower();

            return $"{endereco}@{_dominios[random.Next(_dominios.Length)]}";
        }

        public static string GenerateDataNascimento(int idadaMinima = 0, int idadeMaxima = 80, string formatoSaida = "ddMMyyyy")
        {
            DateTime result;
            var random = new Random();
            var dia = random.Next(1, 31).ToString().PadLeft(2, '0');
            var mes = random.Next(1, 12).ToString().PadLeft(2, '0');
            var ano = random.Next(DateTime.Now.AddYears(-idadeMaxima).Year, DateTime.Now.AddYears(-idadaMinima).Year);

            var dataNascimentoString = $"{dia}{mes}{ano}";           

            bool ok;
            do
            {
               ok = DateTime.TryParseExact(dataNascimentoString, "ddMMyyyy", null, DateTimeStyles.None, out result);

                if (!ok)
                    continue;
               if (result < DateTime.Now.AddYears(-idadeMaxima).Date || result > DateTime.Now.AddYears(-idadaMinima).Date)
                    ok = false;                  
            } while (!ok);

            return result.ToString(formatoSaida);
        }

        public static string GenerateTelefoneCelular(bool comMascara = false)
        {
            var random = new Random();
            var ddd = random.Next(_ddds.Length);
            var primeiroDigito = random.Next(5, 9);
            string restoNumero = null;
                
            for (var i = 0;  i < 7; i++)
                restoNumero += random.Next(0, 9);

            var result = $"{ddd}9{primeiroDigito}{restoNumero}";

            if (!comMascara)
                return result;

            return string.Format("{0:(##) #####-####}", long.Parse(result));
        }
        #endregion
    }
}
