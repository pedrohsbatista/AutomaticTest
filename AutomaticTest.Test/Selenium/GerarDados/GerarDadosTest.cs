namespace AutomaticTest.Test.Selenium.GerarDados
{
    public class GerarDadosTest : DSL
    {
        [Test]
        public void GerarNome()
        {
            var result = GenerateNomeSobrenome();
            Console.WriteLine(result);
        }

        [Test]
        public void GerarEmail()
        {
            var result = GenerateEmail();
            Console.WriteLine(result);

            result = GenerateEmail("usuarioa");
            Console.WriteLine(result);
        }

        [Test]
        public void GerarDataNascimento()
        {
            var result = GenerateDataNascimento();
            Console.WriteLine(result);

            result = GenerateDataNascimento(18);
            Console.WriteLine(result);

            result = GenerateDataNascimento(18, 60);
            Console.WriteLine(result);

            result = GenerateDataNascimento(18, 60, "dd/MM/yyyy");
            Console.WriteLine(result);
        }

        [Test]
        public void GerarTelefoneCelular()
        {
            var result = GenerateTelefoneCelular();
            Console.WriteLine(result);

            result = GenerateTelefoneCelular(true);
            Console.WriteLine(result);
        }
    }
}
