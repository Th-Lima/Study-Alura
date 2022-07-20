namespace Builder
{
    public class Reprovado : IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orcamentos reprovados não recebem desconto extra");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento já esta em esta reprovado");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento já esta em esta reprovado, nao pode ser reprovado novamente");
        }
    }
}
