namespace Decorator
{
    public abstract class Imposto
    {
        public Imposto OutroImposto { get; set; }

        public abstract double Calcula(Orcamento orcamento);

        public Imposto(Imposto outroImposto)
        {
            OutroImposto = outroImposto;
        }

        public Imposto()
        {
            this.OutroImposto = null;
        }

        protected double CalculoDoOutroImposto(Orcamento orcamento)
        {
            if (OutroImposto == null) return 0;

            return OutroImposto.Calcula(orcamento);
        }
    }
}
