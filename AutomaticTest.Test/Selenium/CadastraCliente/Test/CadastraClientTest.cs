using AutomaticTest.Test.Selenium.CadastraCliente.Core;

namespace AutomaticTest.Test.Selenium.CadastraCliente.Test
{
    public class CadastraClientTest : Base
    {
        [Test]
        public void CadastraCliente()
        {
            ClickByXPath("//a[text()=\"Adicionar\"]");
            WriteByXPath("//input[@id=\"nome\"]", GenerateNomeSobrenome());            
            WriteByXPath("//input[@id=\"email\"]", GenerateEmail());            
            WriteByXPath("//input[@id=\"dataNascimento\"]", GenerateDataNascimento(18));
            WriteByXPath("//input[@id=\"telefoneCelular\"]", GenerateTelefoneCelular(true));           
            ClickByXPath("//button[@type=\"submit\"]");
        }

        [Test]
        public void CadastraClienteSimulacaoUsuario()
        {
            ClickByXPath("//a[text()=\"Adicionar\"]");
            WriteByXPath("//input[@id=\"nome\"]", GenerateNomeSobrenome());
            Wait(2000);
            WriteByXPath("//input[@id=\"email\"]", GenerateEmail());
            Wait(2000);
            WriteByXPath("//input[@id=\"dataNascimento\"]", GenerateDataNascimento(18));
            Wait(2000);
            WriteByXPath("//input[@id=\"telefoneCelular\"]", GenerateTelefoneCelular(true));
            Wait(5000);
            Clear("//input[@id=\"telefoneCelular\"]");
            WriteByXPath("//input[@id=\"telefoneCelular\"]", GenerateTelefoneCelular(true));
            Wait(2000);
            ClickByXPath("//button[@type=\"submit\"]");
        }
    }
}
