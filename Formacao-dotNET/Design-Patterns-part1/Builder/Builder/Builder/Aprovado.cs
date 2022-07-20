namespace Builder
{
    public class Aprovado : IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            orcamento.Valor -= orcamento.Valor * 0.02;
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento já esta em estado de aprovação");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento esta em aprovado, não pode ser aprovado agora");
        }
    }
}
