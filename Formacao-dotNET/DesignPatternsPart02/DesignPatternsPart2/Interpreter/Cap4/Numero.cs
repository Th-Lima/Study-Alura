namespace Interpreter.Cap4
{
    public class Numero : IExpressao
    {
        private int NumeroCalculo;

        public Numero(int numero)
        {
            this.NumeroCalculo = numero;
        }

        public int Avalia()
        {
            return this.NumeroCalculo;
        }
    }
}
