namespace AutomaticTest.Test.Selenium.GerarDados
{
    public class GerarDadosTest : DSL
    {
        [Test]
        public void GerarNome()
        {
            var result = GenerateNome();
            Console.WriteLine(result);
        }
    }
}
