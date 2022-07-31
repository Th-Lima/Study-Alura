namespace Interpreter.Cap4
{
    public class Subtracao : IExpressao
    {
        IExpressao Esquerda;
        IExpressao Direita;

        public Subtracao(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }


        public int Avalia()
        {
            int valorEsquerda = Esquerda.Avalia();
            int valorDireita = Direita.Avalia();

            return valorEsquerda - valorDireita;
        }
    }
}
