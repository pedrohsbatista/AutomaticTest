using AutomaticTest.Test.Selenium.BuscaCep.Core;

namespace AutomaticTest.Test.Selenium.BuscaCep.Test
{
    public class BuscaCepTest : Base
    {
        [Test]
        public void BuscarCep()
        {
            WriteById("endereco", "15085-350", "CEP");
            ClickById("btn_pesquisar", "pesquisar");
            Contains("//*[@id=\"resultado-DNEC\"]/tbody/tr/td[1]", "Avenida José Munia", "resultado");
        }

        [Test]
        public void ValidarEnderecoCompleto()
        {
            WriteById("endereco", "15085-350");
            ClickById("btn_pesquisar");

            string[] columns =
            {
                "Avenida José Munia - até 5801 - lado ímpar",
                "Jardim Redentor",
                "São José do Rio Preto/SP",
                "15085-350"
            };

            for (var i = 0; i < columns.Length; i++)
                Equals($"//*[@id=\"resultado-DNEC\"]/tbody/tr/td[{i + 1}]", columns[i]);
        }

        [Test]
        public void ValidarMultiplosEnderecoCompleto()
        {
            Dictionary<string, dynamic> ceps = new Dictionary<string, dynamic>
            {
                { 
                    "15085-350",
                    new
                    {
                        Logradouro = "Avenida José Munia - até 5801 - lado ímpar",
                        Bairro = "Jardim Redentor",
                        Municipio = "São José do Rio Preto/SP",
                        Cep = "15085-350"
                    }
                },
                { 
                    "15093-340",
                    new
                    {
                        Logradouro = "Avenida Presidente Juscelino Kubitschek de Oliveira - de 4200/4201 ao fim",
                        Bairro = "Iguatemi",
                        Municipio = "São José do Rio Preto/SP",
                        Cep = "15093-340"
                    }
                },
                { 
                    "15090-900",
                    new
                    {
                        Logradouro = "Avenida Brigadeiro Faria Lima, 6363\r\nRio Preto Shopping Center",
                        Bairro = "Jardim Morumbi",
                        Municipio = "São José do Rio Preto/SP",
                        Cep = "15090-900"
                    }
                },
                { 
                    "15046-355",
                    new
                    {
                        Logradouro = "Avenida Alfredo Antonio de Oliveira - até 2398/2399",
                        Bairro = "Jardim Marajó",
                        Municipio = "São José do Rio Preto/SP",
                        Cep = "15046-355"
                    }
                }
            };

            var index = 1;

            foreach(var cep in ceps) 
            {
                WriteByXPath("//*[@id=\"endereco\"]", cep.Key, "CEP");
                ClickByXPath("//*[@id=\"btn_pesquisar\"]", "pesquisar");

                for (short i = 1; i <= 4; i++)
                {
                    var xPath = $"//*[@id=\"resultado-DNEC\"]/tbody/tr/td[{i}]";

                    if (i == 1 && ExistElement($"{xPath}/a"))
                        xPath += "/a";

                    var (column, value) = ((string, string)) GetProperty(i, cep.Value);
                    Equals(xPath, value, $"coluna {column.ToLower()}");                    
                };                 

                if (index < ceps.Count)
                    ClickByXPath("//*[@id=\"btn_nbusca\"]", "nova busca");

                index++;
            }
        }

        [Test]
        public void BuscarCepComTipoCep()
        {
            WriteByXPath("//input[@id=\"endereco\"]", "15085-350", "CEP");            
            SelectItemMenuDropDownByXPath("//select[@id=\"tipoCEP\"]", "Grande Usuário", "tipo do CEP");            
            ClickByXPath("//button[@id=\"btn_pesquisar\"]", "pesquisar");            
        }

        [Test]
        public void ValidarOpcoesSelectTipoCep()
        {
            var options = new string[]
            {
               "Localidade/Logradouro",
               "CEP Promocional",
               "Caixa Postal Comunitária",
               "Grande Usuário",
               "Unidade Operacional",               
               "Todos"               
            };
            ValidateItensSelectMenuDropDown("//select[@id=\"tipoCEP\"]", options, "tipo do CEP");
        }

        private (string, string) GetProperty(short index, dynamic obj)
        {
            return index switch
            {
                1 => (nameof(obj.Logradouro), obj.Logradouro),
                2 => (nameof(obj.Bairro), obj.Bairro),
                3 => (nameof(obj.Municipio), obj.Municipio),
                4 => (nameof(obj.Cep), obj.Cep)
            };
        }
    }
}
