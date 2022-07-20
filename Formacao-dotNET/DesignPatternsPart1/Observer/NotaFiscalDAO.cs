namespace Observer
{
    public class NotaFiscalDAO : IAcaoAposGerarUmaNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Simula salvamento no banco");
        }
    }
}
