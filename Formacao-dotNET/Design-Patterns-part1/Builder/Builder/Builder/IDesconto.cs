namespace Builder
{
    public interface IDesconto
    {
        IDesconto Proximo { get; set; }

        double Desconta(Orcamento orcamento);
    }
}
