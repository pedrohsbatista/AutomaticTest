using AutomaticTest.Test.Selenium.BuscaCep.Core;

namespace AutomaticTest.Test.Selenium.BuscaCep.Test
{
    public class BuscaCepTest : Base
    {
        [Test]
        public void BuscarCep()
        {
            WriteById("endereco", "15085-350");
            Click("btn_pesquisar");
            Contains("//*[@id=\"resultado-DNEC\"]/tbody/tr/td[1]", "Avenida José Munia - até 5801 - lado ímpar");
        }
    }
}
