namespace Bridges.Cap6
{
    public class MensagemAdministrativa : IMensagem
    {
        public string Nome { get; set; }
        public IEnviador Enviador { get; set; }

        public MensagemAdministrativa(string nome)
        {
            Nome = nome;
        }

        public void Envia()
        {
            Enviador.Envia(this);
        }

        public string Formata()
        {
            return string.Format($"Enviando a mensagem para o admistrador {Nome}");
        }
    }
}
