namespace Observer
{
    public class EnviadorDeSms : IAcaoAposGerarUmaNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Simula envio por sms");
        }
    }
}
