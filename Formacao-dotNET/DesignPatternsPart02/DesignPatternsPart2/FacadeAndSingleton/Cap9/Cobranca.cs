namespace FacadeAndSingleton.Cap9
{
    public class Cobranca
    {
        public Tipo tipo;
        public Fatura fatura;

        public Cobranca(Tipo tipo, Fatura fatura)
        {
            this.tipo = tipo;
            this.fatura = fatura;
        }

        public void Emite()
        {
        }
    }
}
