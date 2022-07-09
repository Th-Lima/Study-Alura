namespace Decorator
{
    public abstract class TemplateDeImpostoCondicional : Imposto
    {
        public TemplateDeImpostoCondicional(Imposto outroImposto) : base(outroImposto) { }

        public TemplateDeImpostoCondicional() : base() { }

        public override double Calcula(Orcamento orcamento)
        {
            if (DeveUserMaximaTaxacao(orcamento))
            {
                return MaximaTaxacao(orcamento);
            }

            return MinimaTaxacao(orcamento);
        }

        protected abstract bool DeveUserMaximaTaxacao(Orcamento orcamento);
        protected abstract double MaximaTaxacao(Orcamento orcamento);
        protected abstract double MinimaTaxacao(Orcamento orcamento);
    }
}
