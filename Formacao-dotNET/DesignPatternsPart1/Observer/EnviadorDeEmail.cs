namespace Observer
{
    public class EnviadorDeEmail : IAcaoAposGerarUmaNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Simula envio por email");
        }
    }
}
