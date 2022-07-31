namespace Bridges.Cap6
{
    public class MensagemDoCliente : IMensagem
    {
        public string Nome { get; set; }
        public IEnviador Enviador { get; set; }

        public MensagemDoCliente(string nome)
        {
            this.Nome = nome;
        }

        public void Envia()
        {
            Enviador.Envia(this);
        }

        public string Formata()
        {
            return string.Format($"Mensagem para o cliente {Nome}");
        }
    }
}
