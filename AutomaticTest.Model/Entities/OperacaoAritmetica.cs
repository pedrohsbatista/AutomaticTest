using AutomaticTest.Model.Enums;

namespace AutomaticTest.Model.Entities
{
    public class OperacaoAritmetica
    {
        public OperacaoAritmetica()
        {
        }

        public OperacaoAritmetica(int numero1, int numero2)
        {
            Numero1 = numero1;
            Numero2 = numero2;
        }

        public int Numero1 { get; set; }
        public int Numero2 { get; set; }
        public int ResultadoEsperado { get; set; }
        public int ResultadoOperacao { get; set; }
        public TipoOperacaoAritmetica TipoOperacaoAritmetica { get; set; }

        public void SetResultadoOperacao(TipoOperacaoAritmetica tipoOperacaoAritmetica, int resultadoEsperado, int resultadoOperacao)
        {
            TipoOperacaoAritmetica = tipoOperacaoAritmetica;
            ResultadoEsperado  = resultadoEsperado;
            ResultadoOperacao = resultadoOperacao;
        }
    }
}
