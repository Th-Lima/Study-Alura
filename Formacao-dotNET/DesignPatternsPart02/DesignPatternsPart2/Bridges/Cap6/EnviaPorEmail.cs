namespace Bridges.Cap6
{
    public class EnviaPorEmail : IEnviador
    {
        public void Envia(IMensagem mensagem)
        {
            Console.WriteLine("Enviando a mensagem por Email");
            Console.WriteLine(mensagem.Formata());
        }
    }
}
