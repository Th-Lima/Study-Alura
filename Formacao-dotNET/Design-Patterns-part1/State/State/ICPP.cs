namespace State
{
    /// <summary>
    /// Template Method Class
    /// </summary>
    public class ICPP : TemplateDeImpostoCondicional
    {
        public ICPP() : base() { }
        public ICPP(Imposto outroImposto) : base(outroImposto) { }

        protected override bool DeveUserMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }
}
