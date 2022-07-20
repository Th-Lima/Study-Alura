namespace Builder
{
    public class Orcamento
    {
        public IEstadoDeUmOrcamento EstadoAtual { get; set; }

        public double Valor { get; set; }
        public List<Item> Itens { get; set; }

        public Orcamento(double valor)
        {
            Valor = valor;
            Itens = new List<Item>();
            this.EstadoAtual = new EmAprovacao();
        }

        public void AdicionaItem(Item item)
        {
            Itens.Add(item);
        }

        public void AplicaDescontoExtra()
        {
            EstadoAtual.AplicaDescontoExtra(this);
        }

        public void Aprova()
        {
            EstadoAtual.Aprova(this);
        }

        public void Reprova()
        {
            EstadoAtual.Reprova(this);
        }

        public void Finaliza()
        {
            EstadoAtual.Finaliza(this);
        }
    }
}
