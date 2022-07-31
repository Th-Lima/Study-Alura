namespace Interpreter.Cap4
{
    public class Soma : IExpressao
    {
        private IExpressao Esquerda;
        private IExpressao Direita;

        public Soma(IExpressao esquerda, IExpressao direita)
        {
            this.Esquerda = esquerda;
            this.Direita = direita;
        }

        public int Avalia()
        {
            int valorEsquerda = Esquerda.Avalia();
            int valorDireita = Direita.Avalia();

            return valorEsquerda + valorDireita;
        }
    }
}
