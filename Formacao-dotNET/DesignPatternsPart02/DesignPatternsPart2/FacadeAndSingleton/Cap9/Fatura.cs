namespace FacadeAndSingleton.Cap9
{
    public class Fatura
    {
        public Cliente cliente;
        public double fatura;

        public Fatura(Cliente cliente, double fatura)
        {
            this.cliente = cliente;
            this.fatura = fatura;
        }
    }
}
