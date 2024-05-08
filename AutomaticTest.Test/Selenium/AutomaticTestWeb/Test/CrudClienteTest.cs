using AutomaticTest.Test.Selenium.AutomaticTestWeb.Core;

namespace AutomaticTest.Test.Selenium.AutomaticTestWeb.Test
{
    public class CrudClienteTest : Base
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

        [Test]
        public void ConsultaClientes()
        {
            WaitElementGone("//*[@id=\"loading\"]", 5000);
            CadastraCliente();                       
            WaitElement("//tbody/tr", 5000);
            ClickByXPath("//tbody/tr/td[5]/button[1]", "editar");
        }
    }
}
