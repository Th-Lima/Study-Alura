using Alura.ByteBank.Dominio.Entidades;

namespace Alura.ByteBank.Infraestrutura.Testes.Servicos
{
    public interface IByteBankRepositorio
    {
        public List<Cliente> BuscarClientes();
        public List<Agencia> BuscarAgencias();
        public List<ContaCorrente> BuscarContasCorrentes();
    }
}
