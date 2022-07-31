namespace Bridges.Cap6
{
    public class EnviarPorSMS : IEnviador
    {
        public void Envia(IMensagem mensagem)
        {
            Console.WriteLine("Enviando a mensagem por sms");
            Console.WriteLine(mensagem.Formata());
        }
    }
}
