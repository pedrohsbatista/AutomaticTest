using AutomaticTest.Model.Entities;
using AutomaticTest.Model.Enums;

namespace AutomaticTest.Test
{
    public class OperacaoAritmeticaTest
    {
        private OperacaoAritmetica _operacaoAritmetica;

        [SetUp]
        public void Setup()
        {
            _operacaoAritmetica = new OperacaoAritmetica(10, 15);
        }

        [Test]
        public void Somar()
        {
            var resultado = _operacaoAritmetica.Numero1 + _operacaoAritmetica.Numero2;
            _operacaoAritmetica.SetResultadoOperacao(TipoOperacaoAritmetica.Soma, 25, resultado);
            Assert.That(_operacaoAritmetica.ResultadoOperacao, Is.EqualTo(_operacaoAritmetica.ResultadoEsperado));
            Console.WriteLine($"O resultado da soma � {_operacaoAritmetica.ResultadoOperacao}");
        }

        [Test]
        public void Subtrair()
        {
            var resultado = _operacaoAritmetica.Numero1 - _operacaoAritmetica.Numero2;
            _operacaoAritmetica.SetResultadoOperacao(TipoOperacaoAritmetica.Subtracao, -5, resultado);
            Assert.That(_operacaoAritmetica.ResultadoOperacao, Is.EqualTo(_operacaoAritmetica.ResultadoEsperado));
            Console.WriteLine($"O resultado da subtra��o � {_operacaoAritmetica.ResultadoOperacao}");
        }

        [Test]
        public void Multiplicar()
        {
            var resultado = _operacaoAritmetica.Numero1 * _operacaoAritmetica.Numero2;
            _operacaoAritmetica.SetResultadoOperacao(TipoOperacaoAritmetica.Multiplicacao, 150, resultado);
            Assert.That(_operacaoAritmetica.ResultadoOperacao, Is.EqualTo(_operacaoAritmetica.ResultadoEsperado));
            Console.WriteLine($"O resultado da multiplica��o � {_operacaoAritmetica.ResultadoOperacao}");
        }

        [Test]
        public void Dividir()
        {
            var resultado = _operacaoAritmetica.Numero1 / _operacaoAritmetica.Numero2;
            _operacaoAritmetica.SetResultadoOperacao(TipoOperacaoAritmetica.Divisao, 0, resultado);
            Assert.That(_operacaoAritmetica.ResultadoOperacao, Is.EqualTo(_operacaoAritmetica.ResultadoEsperado));
            Console.WriteLine($"O resultado da divis�o � {_operacaoAritmetica.ResultadoOperacao}");
        }

        [TestCase(15, 10, 5)]
        public void Mod(int numero1, int numero2, int resultadoEsperado)
        {
            _operacaoAritmetica = new OperacaoAritmetica(numero1, numero2);
            var resultadoOperacao = numero1 % numero2;
            _operacaoAritmetica.SetResultadoOperacao(TipoOperacaoAritmetica.Mod, resultadoEsperado, resultadoOperacao);
            Assert.That(resultadoOperacao, Is.EqualTo(resultadoEsperado));
            Console.WriteLine($"O resultado do resto da divis�o � {resultadoEsperado}");
        }

        [Test]
        public void All()
        {
            Somar();
            Subtrair();
            Multiplicar();
            Dividir();
            Mod(15, 10, 5);
        }

        [TearDown]
        public void Resultado()
        {
            if (_operacaoAritmetica.ResultadoEsperado != _operacaoAritmetica.ResultadoOperacao)
            {
                Console.WriteLine($"Erro na opera��o: {_operacaoAritmetica.TipoOperacaoAritmetica}");
                Console.WriteLine($"Resultado esperado: {_operacaoAritmetica.ResultadoEsperado}");
                Console.WriteLine($"Resultado opera��o: {_operacaoAritmetica.ResultadoOperacao}");
                Assert.Fail();
            }
            else
            {
                Console.WriteLine($"As opera��es foram executadas corretamente");
            }
        }
    }
}