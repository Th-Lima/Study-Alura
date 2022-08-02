namespace FacadeAndSingleton.Cap9
{
    public class ContatoCliente
    {
        public Cliente cliente;
        public Cobranca cobranca;

        public ContatoCliente(Cliente cliente, Cobranca cobranca)
        {
            this.cliente = cliente;
            this.cobranca = cobranca;  
        }

        public void Dispara()
        {

        }
    }
}
