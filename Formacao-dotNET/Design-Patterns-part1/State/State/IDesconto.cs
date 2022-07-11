namespace State
{
    public interface IDesconto
    {
        IDesconto Proximo { get; set; }

        double Desconta(Orcamento orcamento);
    }
}
