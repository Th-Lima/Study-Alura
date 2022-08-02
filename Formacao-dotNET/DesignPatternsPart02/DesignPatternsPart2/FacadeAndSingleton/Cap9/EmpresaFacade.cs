namespace FacadeAndSingleton.Cap9
{
    public class EmpresaFacade
    {
        public Cliente BuscaCliente(string cpf)
        {
            return ClienteDAO.BuscaPorCpf(cpf);
        }

        public Fatura CriaFatura(Cliente cliente, double fatura)
        {
            return new Fatura(cliente, fatura);
        }

        public Cobranca GeraCobranca(Tipo tipo, Fatura fatura)
        {
            Cobranca cobranca = new Cobranca(tipo, fatura);
            cobranca.Emite();
            
            return cobranca;
        }

        public ContatoCliente FazContato(Cliente cliente, Cobranca cobranca) 
        {
            ContatoCliente contato = new ContatoCliente(cliente, cobranca);
            contato.Dispara();

            return contato;
        }
    }
}
